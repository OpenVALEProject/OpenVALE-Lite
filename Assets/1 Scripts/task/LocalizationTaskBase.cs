using System;
using System.Collections;
using UnityEngine;

abstract public class LocalizationTaskBase : MonoBehaviour {

    public GameObject responseHighlighter;
    public GameObject targetHighlighter;
    public UIRotator rotatingDisplay;

    protected int songSourceNum = -1;
    protected string speakerId = "";
    protected bool userStarted = false;
    protected bool sessionComplete = false;
    private ResultWriter resultWriter;
    protected int trialNumber = 0;
    private DateTime trialStartTime;
    public bool Initialized { get; private set; }

    protected SteamAudioSourceControl steamControl;
    private static System.Random random = new System.Random();  // Only one random ever needed

    // Start is called before the first frame update
    void Start() {
        steamControl = GameObject.FindGameObjectWithTag("SteamManager").GetComponent<SteamAudioSourceControl>();
        resultWriter = new ResultWriter(ConfigurationUtil.outputDir);

        // Enable snapped hand cursor
        var inputController = GetComponent<InputController>();
        inputController.enableInputDevices(true);
        inputController.enableNumberPanels(false);
        ConfigurationUtil.currentCursorType = ConfigurationUtil.CursorType.snapped;
        ConfigurationUtil.currentCursorAttachment = ConfigurationUtil.CursorAttachment.hand;

        // Get HRTF from config
        steamControl.LoadHrtfsFromStreamingAssets();
        int status = steamControl.SetHrtf(ConfigurationUtil.hrtfFile);

        // Initial prompt to let user start when ready
        rotatingDisplay.setMessage("Fire to begin");

        Initialized = true;
    }

    // Update is called once per frame
    protected virtual void Update() {
        if (!ConfigurationUtil.waitingForResponse && !sessionComplete) {
            ConfigurationUtil.waitingForResponse = true;
            Messenger.WaitForMessage("clickLocation", message => {
                Vector3? clickedLocation = Vector3FromString(message);
                if (clickedLocation == null) return;
                var clickedSpeaker = GetComponent<ALFLeds>().getNearestSpeakerID((Vector3) clickedLocation);
                var clickedFlt = HelperFunctions.UnityXYZToFLT((Vector3) clickedLocation);
                if (userStarted) {
                    var correctLocation = GetComponent<ALFLeds>().getSpeakerByID(speakerId).transform.position;
                    var targetFlt = HelperFunctions.UnityXYZToFLT(correctLocation);
                    var error = Vector3.Distance((Vector3) clickedLocation, correctLocation);
                    var clipName = steamControl.GetAudioClip(songSourceNum).name;
                    var elapsedSec = (DateTime.Now - trialStartTime).TotalSeconds;
                    resultWriter.WriteResult(speakerId, targetFlt, clickedSpeaker, clickedFlt, elapsedSec,
                        error.ToString(), ConfigurationUtil.hrtfFile, clipName);
                    UpdateEnvironmentForSelection(clickedSpeaker);
                } else {
                    UpdateSpeakerPosition();
                    rotatingDisplay.setMessage("Select the location the sound is coming from", length: 3f);
                    userStarted = true;
                }
            });
        }
    }

    public virtual void Refresh() {
        if (steamControl) {
            steamControl.SetHrtf(ConfigurationUtil.hrtfFile);
        }
    }

    public virtual void Reset() {
        resultWriter?.Close();
        resultWriter = new ResultWriter(ConfigurationUtil.outputDir);
        trialNumber = 0;
        userStarted = false;
        sessionComplete = false;
        ConfigurationUtil.waitingForResponse = false;
        rotatingDisplay.setMessage("Fire to begin");
        Refresh();
        UpdateSpeakerPosition();
    }

    void OnDisable() {
        songSourceNum = -1;
        steamControl.reset();
        Messenger.ClearMessageListeners();
        ConfigurationUtil.waitingForResponse = false;
    }

    protected abstract void LoadAudioSource(Vector3 initialPosition);
    protected abstract void MoveAudioSource(Vector3 position);

    private void UpdateSpeakerPosition() {
        // Speakers are numbered 1-277. Upper bound of Next is exclusive.
        speakerId = random.Next(1, 278).ToString();
        var speakerPos = GetComponent<ALFLeds>().getSpeakerByID(speakerId).transform.position;
        HandlePositionUpdate(speakerPos);
        trialStartTime = DateTime.Now;
    }

    protected virtual void HandlePositionUpdate(Vector3 position) {
        if (userStarted) {
            MoveAudioSource(position);
        } else {
            LoadAudioSource(position);
        }
    }

    private void UpdateEnvironmentForSelection(string selectedId) {
        bool correct = selectedId == speakerId;
        UpdateMessage(correct);
        UpdateHighlightColor(selectedId);
        if (++trialNumber >= ConfigurationUtil.numTrials) {
            CompleteTask();
        } else {
            UpdateSpeakerPosition();
        }
    }

    private void UpdateMessage(bool correct) {
        string message = correct ? "Correct! " : "";
        message += "Now find the new location";
        rotatingDisplay.setMessage(message, length: 3f);
    }

    private void UpdateHighlightColor(string selectedId) {
        var green = new Color(0f, 1f, 0f, 0.8f);
        var red = new Color(1f, 0f, 0f, 0.8f);
        var responseColor = selectedId == speakerId ? green : red;
        StopAllCoroutines();
        StartCoroutine(ActivateHighlighterCouroutine(selectedId, responseHighlighter, responseColor));
        if (!ConfigurationUtil.hideResult) {
            StartCoroutine(ActivateHighlighterCouroutine(speakerId, targetHighlighter, green));
        }
    }

    private IEnumerator ActivateHighlighterCouroutine(String targetId, GameObject highlighter, Color color) {
        highlighter.transform.position = GetComponent<ALFLeds>().getSpeakerByID(targetId).transform.position;
        highlighter.GetComponent<Renderer>().material.SetColor("_Color", color);

        highlighter.SetActive(true);
        yield return new WaitForSeconds(3f);
        highlighter.SetActive(false);
    }

    private Vector3? Vector3FromString(string vectorString) {
        string noParens = vectorString.Substring(1, vectorString.Length - 2);
        string[] stringValues = noParens.Split(new string[] { ", " }, StringSplitOptions.None);
        if (stringValues.Length != 3) {
            return null;
        }
        float floatX, floatY, floatZ;
        if (!float.TryParse(stringValues[0], out floatX)) {
            return null;
        }
        if (!float.TryParse(stringValues[1], out floatY)) {
            return null;
        }
        if (!float.TryParse(stringValues[2], out floatZ)) {
            return null;
        }
        return new Vector3(floatX, floatY, floatZ);
    }

    private void CompleteTask() {
        sessionComplete = true;
        rotatingDisplay.setMessage("Testing complete!");
        steamControl.enableSource(songSourceNum, false);
    }

    void OnApplicationQuit() {
        resultWriter?.Close();
    }

}
