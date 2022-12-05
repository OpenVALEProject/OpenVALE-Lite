using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SteamAudioSourceControl : MonoBehaviour {

    public GameObject steamAudioSourceObject;
    public Dictionary<int,float> storedVolumes = new Dictionary<int, float>();

    private SteamAudio.SteamAudioManager steamAudioManager;
    private string hrtfPath = $@"{Application.streamingAssetsPath}\hrtf";
    private string normalizedHrtfPath = $@"{Application.streamingAssetsPath}\normhrtf";

    void Awake() {
        steamAudioManager = gameObject.GetComponent<SteamAudio.SteamAudioManager>();
    }

    /*
     Note: SteamAudio requires HRTFs to be placed in Assets/StreamingAssets (OpenVale_Data/StreamingAssets at runtime)
    */
    public void LoadHrtfsFromStreamingAssets() {
        steamAudioManager.Destroy();
        if (!Directory.Exists(normalizedHrtfPath)) {
            Directory.CreateDirectory(normalizedHrtfPath);
        }
        // Normalize all when loaded.... Save to temp dir and use that temp dir as actual HRTFs
        // TODO:
        //  Get all SOFAs (like below)
        //  Create temp dir in same dir as sofas
        //  Normalize all
        //  Add all normalized SOFAs in temp dir to SAM
        //  Remember to delete temp when done
        var sofaFiles = new DirectoryInfo(hrtfPath).GetFiles("*.sofa", SearchOption.AllDirectories);
        foreach (var file in sofaFiles) {
            file.CopyTo($@"{normalizedHrtfPath}\{file.Name}", true);
        }
        var normSofaFiles = new DirectoryInfo(normalizedHrtfPath).GetFiles("*.sofa", SearchOption.AllDirectories);
        steamAudioManager.sofaFiles = new string[normSofaFiles.Length];
        for (int i = 0; i < normSofaFiles.Length; i++) {
            // HrtfNormalizer.NormalizeHrtf(normSofaFiles[i].FullName);
            var relativePath = normSofaFiles[i].FullName.Split(
                new string[1]{Application.streamingAssetsPath.Replace('/', '\\')}, StringSplitOptions.None)[1];
            steamAudioManager.sofaFiles[i] = relativePath.Substring(1).Replace('\\', '/');
        }

        // Must reinitialize the audio system after loading in the new HRTFs
        steamAudioManager.Initialize(SteamAudio.GameEngineStateInitReason.Playing);
    }

    /**
    Set HRTF by file name. Use name of the file without the .sofa extension.
    */
    public int SetHrtf(string hrtfFileName) {
        var files = new DirectoryInfo(normalizedHrtfPath).GetFiles("*.sofa", SearchOption.AllDirectories);
        for (int i = 0; i < files.Length; i++) {
            if (files[i].Name.Equals(hrtfFileName + ".sofa")) {
                // Default HRTF is 0, so custom HRTF indices are shifted up by 1
                // IndexOf returns -1 if not found, so this sets the default HRTF in that case
                return SetHrtf(i + 1);
            }
        }
        steamAudioManager.currentSOFAFile = 0;
        return (int)ERRORMESSAGES.ErrorType.ERR_AS_HRTFFILELOADFAILURE;
    }

    /**
    Set HRTF by index. 0 is default, others are HRTF array index + 1.
    */
    public int SetHrtf(int hrtfNum) {
        if(hrtfNum <= steamAudioManager.sofaFiles.Length) {
            steamAudioManager.currentSOFAFile = hrtfNum;
            return (int)ERRORMESSAGES.ErrorType.ERR_AS_NONE;
        } else {
            steamAudioManager.currentSOFAFile = 0;
            return (int)ERRORMESSAGES.ErrorType.ERR_AS_HRTFFILELOADFAILURE;
        }
    }

    private IEnumerator AwaitWebRequest(Vector3 position, string url, Action<int> sourceNumHandler, bool isAmbi, string name) {
        int sourceNum = -1;
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(url,AudioType.WAV)) {
            yield return uwr.SendWebRequest();
            // Execution continues from the coroutine after the web request completes
            var clip = DownloadHandlerAudioClip.GetContent(uwr);
            clip.name = name;
            sourceNum = SetSingleAudioClip(clip, isAmbi);
        }

        if (!isAmbi && sourceNum != -1) {
            moveSource(sourceNum, position);
        } else {
            moveSource(sourceNum, Vector3.zero);
        }

        sourceNumHandler(sourceNum);
    }

    public void LoadSong(Vector3 position, string path, Action<int> sourceNumHandler, bool isAmbi = false) {
        path = path.Replace('\\', '/');
        // Gets string after the last / in the file path, which should be the file name
        string fileName = path.Substring(path.LastIndexOf('/') + 1);
        string url = string.Format("file://{0}", path);
        StartCoroutine(AwaitWebRequest(position, url, sourceNumHandler, isAmbi, fileName));
    }

    public int LoadNoiseFile() {
        var noiseClip = Resources.Load<AudioClip>("wavs/noise");
        return SetSingleAudioClip(noiseClip);
    }

    private int SetSingleAudioClip(AudioClip clip, bool isAmbi = false) {
        var sourceHelper = steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>();
        sourceHelper.clearSources();
        return sourceHelper.addClip(clip, isAmbi);
    }

    public void moveSource(int id, Vector3 position)
    {
        if (steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(id).clip.ambisonic)
        {
            Quaternion rotation = Quaternion.LookRotation(position);
            //steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(id).transform.rotation.SetLookRotation(position);
            rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, -rotation.eulerAngles.y, rotation.eulerAngles.z);
            //rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z);
            steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(id).transform.rotation = rotation;
        }
        else
            steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(id).transform.position = position;
    }
    public int muteSource(int sourceNum, bool mute)
    {
        steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(sourceNum).mute = mute;

        return (int)ERRORMESSAGES.ErrorType.ERR_AS_NONE;
    }
    public int setSourceVolume(int id, float volume)
    {
        steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(id).volume = volume;
        return 0;
    }
    public void setAllSourceVolumes(float volume)
    {
        steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().setSourceVolumes(volume);
    }
    public void reset() {
        // Never trust the regular null safe ?. or ?? calls... Unity is stupid
        // https://github.com/JetBrains/resharper-unity/wiki/Possible-unintended-bypass-of-lifetime-check-of-underlying-Unity-engine-object
        if (steamAudioSourceObject) {
            steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().clearSources();
        }
    }
    public void rewindClip(int sourceNumber)
    {
        steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(sourceNumber).time =0f;
    }
    public int enableSource(int sourceNum, bool enabled)
    {
        if(enabled)
        {
            steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(sourceNum).Play();
            steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(sourceNum).mute = true;
        }
        else
        {
            steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(sourceNum).Stop();
        }
        return 0;
    }

    public bool IsSourcePlaying(int sourceNum) {
        var audio = steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(sourceNum);
        return audio.isPlaying && !audio.mute;
    }

    public AudioClip GetAudioClip(int id) => steamAudioSourceObject.GetComponent<SteamAudioSourceHelper>().getSourceFromIndex(id).clip;

}