using UnityEngine;

public class MotionHandler : MonoBehaviour {
    
    public new GameObject camera;

    void Update() {
        if (!ConfigurationUtil.useRift && !ConfigurationUtil.useVive) {
            if (Input.GetKey(KeyCode.A)) {
                camera.transform.Rotate(Vector3.up, -.1f);
            } else if (Input.GetKey(KeyCode.D)) {
                camera.transform.Rotate(Vector3.up, .1f);
            } else if (Input.GetKey(KeyCode.W)) {
                camera.transform.Rotate(Vector3.right, -.1f);
            } else if (Input.GetKey(KeyCode.S)) {
                camera.transform.Rotate(Vector3.right, .1f);
            }
        }
        // Is anything needed for VR cameras?
    }
}
