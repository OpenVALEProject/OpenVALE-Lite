using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour {

    public MenuSwitcher menuSwitcher;
    public GameObject crossHair;

    private int uiLayerMask;
    private int foregroundUiLayerMask;

    void Start() {
        foregroundUiLayerMask = 1 << LayerMask.NameToLayer("ForegroundUI");
        uiLayerMask = 1 << LayerMask.NameToLayer("UI");
    }

    void Update() {
        if (EventSystem.current.currentSelectedGameObject?.GetComponent<TMPro.TMP_InputField>() == null) {
            // Input fields need to keep focus, other things don't
            EventSystem.current.SetSelectedGameObject(null);
        }
        if (ConfigurationUtil.useRift) {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)
                || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch)) {
                TriggerPressed();
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.RTouch)) {
                EscapeButtonPressed();
            }
         } else {
            if (Input.GetKeyDown(KeyCode.Space)) {
                TriggerPressed();
            }
            if (Input.GetKeyDown(KeyCode.Q)) {
                EscapeButtonPressed();
            }
         }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    private void TriggerPressed() {
        if (ConfigurationUtil.waitingForResponse && !menuSwitcher.menuEnabled) {
            Vector3 intersectionPoint = Vector3.zero;
            if (ConfigurationUtil.useRift || ConfigurationUtil.useVive) {
                if (ConfigurationUtil.currentCursorAttachment == ConfigurationUtil.CursorAttachment.hand) {
                    intersectionPoint = RaySphereIntersection(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch), ((OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward).normalized) * 10);
                } else if (ConfigurationUtil.currentCursorAttachment == ConfigurationUtil.CursorAttachment.hmd) {
                    if (ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.snapped)
                        intersectionPoint = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye) * Vector3.forward * 2.07f;
                    else if (ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.snappedLED)
                        intersectionPoint = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye) * Vector3.forward;
                    else if (ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.crosshair) {
                        intersectionPoint = (crossHair.transform.position - UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye)).normalized * 2.08f;
                    }
                }
            } else {
                intersectionPoint = Camera.main.transform.forward.normalized * 2.07f;
            }

            Messenger.PublishMessage("clickLocation", intersectionPoint.ToString());

            ConfigurationUtil.waitingForResponse = false;
            ConfigurationUtil.waitingForResponseOrientation = false;
            ConfigurationUtil.waitStartTime = 0.0f;
        } else {
            Vector3 origin = Vector3.zero;
            Vector3 toDirection = Vector3.zero;
            if (!ConfigurationUtil.useRift && !ConfigurationUtil.useVive && Input.GetKeyDown(KeyCode.Space)) {
                origin = Camera.main.transform.position;
                toDirection = Camera.main.transform.forward;
            } else if (ConfigurationUtil.useRift) {
                origin = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
                toDirection = ((OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward).normalized) * 10f;
            }
            Ray r = new Ray(origin, toDirection);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit, Mathf.Infinity, foregroundUiLayerMask)) {
                // Try to hit foreground object before other objects
                var hitObject = hit.collider.gameObject;
                ExecuteEvents.Execute(hitObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
                if (!hitObject.GetComponent<VRKeys.Key>()) {
                    EventSystem.current.SetSelectedGameObject(hitObject);
                }
                return;
            }
            if (Physics.Raycast(r, out hit, Mathf.Infinity, uiLayerMask)) {
                // Simulate click on object
                var hitObject = hit.collider.gameObject;
                ExecuteEvents.Execute(hitObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
                if (!hitObject.GetComponent<VRKeys.Key>()) {
                    EventSystem.current.SetSelectedGameObject(hitObject);
                }
            }
        }
    }

    private void EscapeButtonPressed() => menuSwitcher.SetMenuEnabled(false);

    private Vector3 RaySphereIntersection(Vector3 orig, Vector3 dir){
        Ray r = new Ray(orig, dir);
        RaycastHit[] hits = Physics.RaycastAll(r, 50);
        Vector3 sphereHitPoint = new Vector3(0,-1,0);
        foreach (RaycastHit RCH in hits)
        {
            GameObject collisionObject = RCH.collider.gameObject;
            if(collisionObject.tag.Equals("ALFSphere")){
                sphereHitPoint = RCH.point;
            }
        }
        return sphereHitPoint;
    }

}
