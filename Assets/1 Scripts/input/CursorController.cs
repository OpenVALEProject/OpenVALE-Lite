using UnityEngine;

public class CursorController : MonoBehaviour {

    public GameObject crossHair;
    public float crossHairDepth;
    public Transform VIVEOffset;
    public new GameObject camera;
    private GameObject currentHighlightedObject = null;

    void Update() {
        // Remove highlights if anything is highlighted
        if (currentHighlightedObject != null) {
            if(ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.snappedLED)
                currentHighlightedObject.GetComponent<LEDControls>().HighlightCenterLED(false);
            else if(ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.snapped)
                currentHighlightedObject.GetComponent<LEDControls>().HighlightLEDs(false, false, false, false);
            else 
                currentHighlightedObject = null;
        }

        if (ConfigurationUtil.currentCursorAttachment == ConfigurationUtil.CursorAttachment.hand) {
            if (ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.crosshair) {
                if (!crossHair.activeSelf) {
                    crossHair.SetActive(true);
                }                
                
                if (ConfigurationUtil.useRift) {
                    crossHair.transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
                    Vector3 intersectionPoint = RaySphereIntersection(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch),((OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward).normalized));
                    crossHair.transform.position = intersectionPoint;
                    crossHair.transform.position = intersectionPoint + ((OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch) - intersectionPoint).normalized*0.12f);                    
                } else if (ConfigurationUtil.useVive) {
                    crossHair.transform.position = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye) + VIVEOffset.position;
                }
                crossHair.transform.LookAt(crossHair.transform.position + (UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye) * Vector3.forward), UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye) * Vector3.up);
                crossHair.transform.Rotate(Vector3.right, -90);           
            } else if (ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.snapped) {
                Vector3 intersectionLocation = Vector3.zero;
                if (ConfigurationUtil.useRift) {
                    intersectionLocation = RaySphereIntersection(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch),((OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward).normalized));
                }
                currentHighlightedObject = GetComponent<ALFLeds>().getNearestSpeaker(intersectionLocation);
                if (currentHighlightedObject != null) {   
                    currentHighlightedObject.GetComponent<LEDControls>().HighlightLEDs(true, true, true, true);
                }
            }
        }
   
        if (ConfigurationUtil.currentCursorAttachment == ConfigurationUtil.CursorAttachment.hmd) {
            if (ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.crosshair) {
                if (!crossHair.activeSelf) {
                    crossHair.SetActive(true);
                }
                crossHair.transform.position = camera.transform.position;
                crossHair.transform.position = transform.position + camera.transform.forward * crossHairDepth;
                crossHair.transform.LookAt(crossHair.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
                crossHair.transform.Rotate(Vector3.right, -90);
            } else if(ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.snapped) {
                Vector3 intersectionLocation = camera.transform.forward.normalized * 2.08f;
                currentHighlightedObject = GetComponent<ALFLeds>().getNearestSpeaker(intersectionLocation);
               
                if (currentHighlightedObject != null) {
                    currentHighlightedObject.GetComponent<LEDControls>().HighlightLEDs(true, true, true, true);
                }
                
            } else if(ConfigurationUtil.currentCursorType == ConfigurationUtil.CursorType.snappedLED) {
                Vector3 intersectionLocation = camera.transform.forward.normalized * 2.08f;
                currentHighlightedObject = GetComponent<ALFLeds>().getNearestLED(intersectionLocation);
                
                if (currentHighlightedObject != null) {
                    currentHighlightedObject.GetComponent<LEDControls>().HighlightCenterLED(true);
                }
            }
        }
    }

    public Vector3 RaySphereIntersection(Vector3 orig, Vector3 dir){
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
