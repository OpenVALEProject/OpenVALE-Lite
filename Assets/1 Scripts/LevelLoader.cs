using UnityEngine;
using System.Xml;
using System.IO;
public class LevelLoader : MonoBehaviour
{

    public GameObject levelController;

    private static bool hasRun = false;


    void Awake()
	{

        if (hasRun) {
            Destroy(gameObject);
            // Must reset the LevelController since it gets rebuilt
            var levelLoader = GameObject.Find("LevelLoader");
            var levelController = GameObject.Find("LevelController");
            var levelLoaderScript = levelLoader.GetComponent<LevelLoader>();
            levelLoaderScript.levelController = levelController;
            LoadLocalizationTask();
            return;
        } else {
            hasRun = true;
        }

        LogSystem.ClearLog();
	    Application.runInBackground = true;
        UnityThread.initUnityThread();
        DontDestroyOnLoad(gameObject);

        XmlDocument configurationDoc = new XmlDocument();
        try {
            configurationDoc.Load(new FileStream(@".\OpenVALEConfig.xml", FileMode.Open));
        } catch (FileNotFoundException ignored) {
            Debug.LogError("Configuration not found!");
            return;
        }

        XmlNodeList settingsNodes = configurationDoc.GetElementsByTagName("setting");
        foreach (XmlNode settingsNode in settingsNodes) {
            string settingName = settingsNode.Attributes["name"].Value;
            string settingValue = settingsNode.InnerText.Trim().Replace('/', '\\');
            switch (settingName) {
                case "WavFile":
                    ConfigurationUtil.wavFile = settingValue;
                    // This setting may be a directory. If so set the dir boolean too.
                    var wavPath = $@"{Application.streamingAssetsPath}\wav\{ConfigurationUtil.wavFile}";
                    ConfigurationUtil.isWavDir = Directory.Exists(wavPath);
                    break;
                case "HMDType":
                    string hmdTypeCheck = settingValue;
                    if (hmdTypeCheck.ToLower().Equals("rift"))
                        ConfigurationUtil.useRift = true;
                    else if (hmdTypeCheck.ToLower().Equals("vive"))
                        ConfigurationUtil.useVive = true;
                    break;
                case "CueMode":
                    ConfigurationUtil.cueMode = settingValue;
                    LoadLocalizationTask();
                    break;
                case "HrtfFile":
                    ConfigurationUtil.hrtfFile = settingValue;
                    break;
                case "HideResult":
                    ConfigurationUtil.hideResult = settingValue == "yes";
                    break;
                case "ResultPath":
                    try {
                        Directory.CreateDirectory(settingValue);
                        ConfigurationUtil.outputDir = settingValue;
                    } catch {
                        // Do nothing, keep default path
                    }
                    break;
                case "NumTrials":
                    ConfigurationUtil.numTrials = int.Parse(settingValue);
                    break;
            }
        }
    }

    private void LoadLocalizationTask() {
        var settingValue = ConfigurationUtil.cueMode;
        if (settingValue.ToLower().Equals("continuous")) {
            levelController.GetComponent<ContinuousCueTask>().enabled = true;
        } else if (settingValue.ToLower().Equals("burst")) {
            levelController.GetComponent<BurstCueTask>().enabled = true;
        } else {
            levelController.GetComponent<EmptyTask>().enabled = true;
        }
    }
}
