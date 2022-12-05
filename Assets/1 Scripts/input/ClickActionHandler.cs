using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRKeys;

public class ClickActionHandler : MonoBehaviour {

    public TMP_Dropdown wavDropdown;
    public TMP_Dropdown hrtfDropdown;
    public Toggle cueContinuousToggle;
    public Toggle cueBurstToggle;
    public Toggle showResultToggle;
    public Toggle hideResultToggle;
    public TMP_Text trialCount;
    public TMP_InputField noteInput;
    public Keyboard keyboard;
    public MenuSwitcher menuSwitcher;

    private List<string> wavDirs;

    void OnEnable() {
        PopulateDropdown(wavDropdown, $@"{Application.streamingAssetsPath}\wav", "*.wav");
        wavDirs = AddDirsDropdown(wavDropdown, $@"{Application.streamingAssetsPath}\wav");
        PopulateDropdown(hrtfDropdown, $@"{Application.streamingAssetsPath}\hrtf", "*.sofa");
        SetDefaultOptions();
    }

    void Update() {
        if (noteInput.isFocused && keyboard.disabled) {
            keyboard.Enable();
        } else if (!noteInput.isFocused && keyboard.enabled) {
            keyboard.Disable();
        }
    }

    private void SetDefaultOptions() {
        wavDropdown.value = wavDropdown.options.FindIndex(option => option.text.Contains(ConfigurationUtil.wavFile));
        hrtfDropdown.value = hrtfDropdown.options.FindIndex(option => option.text.Contains(ConfigurationUtil.hrtfFile));

        cueContinuousToggle.isOn = ConfigurationUtil.cueMode == "continuous";
        cueBurstToggle.isOn = ConfigurationUtil.cueMode == "burst";

        showResultToggle.isOn = !ConfigurationUtil.hideResult;
        hideResultToggle.isOn = ConfigurationUtil.hideResult;

        trialCount.text = ConfigurationUtil.numTrials.ToString();

        keyboard.SetText(ConfigurationUtil.trialNote, true);
    }

    private void PopulateDropdown(TMP_Dropdown dropdown, string assetPath, string fileRegex) {
        dropdown.ClearOptions();
        var files = new DirectoryInfo(assetPath).GetFiles(fileRegex, SearchOption.TopDirectoryOnly);
        foreach (var file in files) {
            var fileName = file.Name.Split('.')[0];
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = fileName });
        }
        dropdown.RefreshShownValue();
    }

    private List<string> AddDirsDropdown(TMP_Dropdown dropdown, string assetPath) {
        // need to get the dirs here for audio files
        var dirs = new DirectoryInfo(assetPath).GetDirectories();
        var dirNames = new List<string>();
        foreach (var file in dirs) {
            var fileName = file.Name.Split('.')[0];
            dirNames.Add($"(D) {fileName}");
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = $"(D) {fileName}" });
        }
        dropdown.RefreshShownValue();
        return dirNames;
    }

    public void OnSave() {
        var wavChoice = wavDropdown.options[wavDropdown.value].text;
        if (wavDirs.Contains(wavChoice)) {
            ConfigurationUtil.isWavDir = true;
            ConfigurationUtil.wavFile = wavChoice.Substring(4);  // Drop prefix
        } else {
            ConfigurationUtil.isWavDir = false;
            ConfigurationUtil.wavFile = wavChoice;
        }

        ConfigurationUtil.hrtfFile = hrtfDropdown.options[hrtfDropdown.value].text;

        if (cueContinuousToggle.isOn) {
            ConfigurationUtil.cueMode = "continuous";
        } else if (cueBurstToggle.isOn) {
            ConfigurationUtil.cueMode = "burst";
        }

        ConfigurationUtil.hideResult = hideResultToggle.isOn;

        ConfigurationUtil.numTrials = GetTrialCountFromText() ?? 1;

        ConfigurationUtil.trialNote = noteInput.text;

        ReturnToTask();
    }

    public void ReturnToTask() => menuSwitcher.SetMenuEnabled(false);

    public void ResetExperiment() {
        menuSwitcher.ResetExperiment();
        ReturnToTask();
    }

    public void DecrementTrialCount() {
        int count = GetTrialCountFromText() ?? 1;
        if (--count > 0) {
            trialCount.text = count.ToString();
        }
    }

    public void IncrementTrialCount() {
        int count = GetTrialCountFromText() ?? 1;
        trialCount.text = (++count).ToString();
    }

    private int? GetTrialCountFromText() {
        int numTrials;
        if (int.TryParse(trialCount.text, out numTrials)) {
            return numTrials;
        } else {
            return null;
        }
    }
}
