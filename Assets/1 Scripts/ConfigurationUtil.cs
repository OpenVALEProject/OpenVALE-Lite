using UnityEngine;

public static class ConfigurationUtil  {
    public enum CursorAttachment{none,hand, hmd};
    public enum CursorType { none, crosshair, snapped, snappedLED};

    public static string hrtfFile = "";
    public static string wavFile = "";
    public static bool isWavDir = false;
    public static bool useRift = false;
    public static bool useVive = false;
    public static CursorType currentCursorType = CursorType.none;
    public static CursorAttachment currentCursorAttachment = CursorAttachment.none;
    public static bool waitingForResponse = false;
    public static bool waitingForResponseOrientation = false;
    public static float waitStartTime = 0.0f;
    public static bool waitingForRecenter = false;
    public static bool waitingForSubjectNum = false;
    public static Vector3 recenterPosition = Vector3.zero;
    public static float recenterTolerance = 0;
    public static bool isAcousticSparkler = true;
    public static int numTrials = -1;
    public static bool hideResult = false;
    public static string outputDir = "TrialResults";
    public static string cueMode = "";
    public static string trialNote = "";
}
