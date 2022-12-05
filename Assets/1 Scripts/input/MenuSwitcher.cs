using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{

    public GameObject menuObject;
    public GameObject alfObject;
    public GameObject sphereMesh;
    public GameObject rotatingText;
    public GameObject wandBase;
    public bool menuEnabled { get; private set; }
    public SteamAudioSourceHelper sourceHelper;

    void Update() {
        if (ConfigurationUtil.useRift) {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) {
                if (!menuObject.activeSelf) {
                    SetMenuEnabled(true);
                }
            }
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch)) {
                if (menuObject.activeSelf) {
                    SetMenuEnabled(false);
                }
            }
         } else {
            if (Input.GetKey(KeyCode.Z)) {
                if (!menuObject.activeSelf) {
                    SetMenuEnabled(true);
                }
            } else if (Input.GetKey(KeyCode.X)) {
                if (menuObject.activeSelf) {
                    SetMenuEnabled(false);
                }
            }
         }

        if (menuEnabled) {
            Vector3 origin = Vector3.zero;
            Vector3 toDirection = Vector3.zero;
            if (!ConfigurationUtil.useRift && !ConfigurationUtil.useVive ) {
                origin = Vector3.zero;
                toDirection = Camera.main.transform.forward;
            } else if (ConfigurationUtil.useRift || ConfigurationUtil.useVive) {
                if (ConfigurationUtil.useRift) {
                    origin = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
                    toDirection = ((OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward).normalized) * 10f;
                    wandBase.transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
                    wandBase.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) ;
                } else if (ConfigurationUtil.useVive) {
                    // origin = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye) + VIVEOffset.position;
                    //toDirection = ((SteamVR_Controller.Input(3).transform.rot * Vector3.forward).normalized * 3f);
                }
            }
        }
    }

    public void SetMenuEnabled(bool enabled) {
        menuEnabled = enabled;
        menuObject.SetActive(enabled);

        alfObject.SetActive(!enabled);
        sphereMesh.SetActive(!enabled);
        rotatingText.SetActive(!enabled);
        wandBase.SetActive(enabled);
        GetComponent<InputHandler>().enabled = !enabled;
        sourceHelper.setSourceVolumes(enabled ? 0f : 1f);

        // Refresh tasks if needed
        if (!enabled) {
            var settingValue = ConfigurationUtil.cueMode;
            var continuousCue = GetComponent<ContinuousCueTask>();
            var burstCue = GetComponent<BurstCueTask>();
            if (settingValue.ToLower().Equals("continuous")) {
                burstCue.enabled = false;
                if (!continuousCue.enabled) {
                    continuousCue.enabled = true;
                    // Initialization does not necessarily happen on enable
                    if (continuousCue.Initialized) {
                        continuousCue.Reset();
                    }
                } else {
                    continuousCue.Refresh();
                }
            } else if (settingValue.ToLower().Equals("burst")) {
                continuousCue.enabled = false;
                if (!burstCue.enabled) {
                    burstCue.enabled = true;
                    // Initialization does not necessarily happen on enable
                    if (burstCue.Initialized) {
                        burstCue.Reset();
                    }
                } else {
                    burstCue.Refresh();
                }
            } else {
                GetComponent<EmptyTask>().enabled = true;
                continuousCue.enabled = false;
                burstCue.enabled = false;
            }
        } else {
            ConfigurationUtil.waitingForResponse = false;
        }
    }

    public void ResetExperiment() {
        var continuousCue = GetComponent<ContinuousCueTask>();
        var burstCue = GetComponent<BurstCueTask>();
        if (continuousCue.enabled) {
            continuousCue.Reset();
        }
        if (burstCue.enabled) {
            burstCue.Reset();
        }
    }
}
