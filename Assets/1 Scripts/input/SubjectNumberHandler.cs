using UnityEngine;
using UnityEngine.EventSystems;

public class SubjectNumberHandler : MonoBehaviour
{
    public GameObject subjectNumberBeam;
    public Transform VIVEOffset;
    private GameObject currentlySelectedButton;

    void Update() {
        if (ConfigurationUtil.waitingForSubjectNum) {
            WaitingForSubjectNumberUI();
        } else {
            subjectNumberBeam.SetActive(false);
        }
    }

    private void WaitingForSubjectNumberUI() {
        subjectNumberBeam.SetActive(true);
        Vector3 origin = Vector3.zero;
        Vector3 toDirection = Vector3.zero;
        if (!ConfigurationUtil.useRift && !ConfigurationUtil.useVive ) {
            origin = Vector3.zero;
            toDirection = Camera.main.transform.forward;
        } else if (ConfigurationUtil.useRift || ConfigurationUtil.useVive) {
            if (ConfigurationUtil.useRift) {
                origin = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
                toDirection = ((OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward).normalized) * 10f;
                subjectNumberBeam.transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
                subjectNumberBeam.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) ;
            } else if (ConfigurationUtil.useVive) {
                origin = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye) + VIVEOffset.position;
                //toDirection = ((SteamVR_Controller.Input(3).transform.rot * Vector3.forward).normalized * 3f);
            }
        }

        Ray r = new Ray(origin, toDirection);
        RaycastHit[] hits = Physics.RaycastAll(r, 50);
        UnityEngine.UI.Button possibleButton;
        bool foundHit = false;
        foreach (RaycastHit RCH in hits){
            possibleButton = RCH.collider.gameObject.GetComponent<UnityEngine.UI.Button>();
            if (possibleButton != null) {
                foundHit = true;
                if (currentlySelectedButton == null ){
                    currentlySelectedButton = RCH.collider.gameObject;
                    currentlySelectedButton.GetComponent<EventTrigger>().OnPointerEnter(null);
                } else if (currentlySelectedButton != possibleButton) {
                    currentlySelectedButton.GetComponent<EventTrigger>().OnPointerExit(null);
                    currentlySelectedButton = RCH.collider.gameObject;
                    currentlySelectedButton.GetComponent<EventTrigger>().OnPointerEnter(null);
                }
            }
        }
        if (!foundHit) {
            if (currentlySelectedButton != null) {
                currentlySelectedButton.GetComponent<EventTrigger>().OnPointerExit(null);
                currentlySelectedButton = null;
            }

        }

    }
}
