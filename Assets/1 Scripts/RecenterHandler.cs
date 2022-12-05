/*
 * Used to communicate with the external Audio Spatialization Tools
*/

using UnityEngine;

public class RecenterHandler : MonoBehaviour
{
    public GameObject joystickCam;
    public GameObject occCam;
    private bool enteredTolerance = false;
    private float toleranceTime = 0.0f;

    public GameObject acousticSparkler;
    public GameObject acousticSparklerSoundLocation;
    private bool sparklerActive = false;

    // Update is called once per frame
    void Update()
    {
        GameObject camera;
        if (!ConfigurationUtil.useRift)
        {
            camera = joystickCam;
        }
        else
        {
            camera = occCam;
        }

        // Manage acoustic sparkler--moves the sound source with the hand control
        if(ConfigurationUtil.isAcousticSparkler){
            if (ConfigurationUtil.useRift && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                sparklerActive = !sparklerActive;
                acousticSparklerSoundLocation.SetActive(sparklerActive);
            }
            acousticSparkler.transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            acousticSparkler.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        }

        if (ConfigurationUtil.waitingForRecenter) {
            Vector3 targetAlignment = (ConfigurationUtil.recenterPosition - camera.transform.position).normalized;
            if (Mathf.Acos(Vector3.Dot(camera.transform.forward, targetAlignment)) < ConfigurationUtil.recenterTolerance)
            {

                if (!enteredTolerance)
                {
                    enteredTolerance = true;
                    toleranceTime = Time.time;
                }
                if (ConfigurationUtil.waitingForResponse)
                {
                    if (ConfigurationUtil.useRift && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        ConfigurationUtil.waitingForResponse = false;
                    }
                    //else if (ConfigurationUtil.useVive && SteamVR_Controller.Input(3).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                    //{
                    //    ConfigurationUtil.waitingForResponse = false;
                    //}
                    else if (!ConfigurationUtil.useRift && !ConfigurationUtil.useVive && Input.GetKeyDown(KeyCode.Space))
                    {
                        ConfigurationUtil.waitingForResponse = false;
                    }
                    else
                        return;

                }
                else {
                    if ((Time.time - toleranceTime) > 0.5f)
                    {
                        enteredTolerance = false;
                        if (Mathf.Acos(Vector3.Dot(camera.transform.forward, targetAlignment)) > ConfigurationUtil.recenterTolerance)
                        {
                            return;
                        }

                    }
                    else {

                        return;
                    }

                }

                ConfigurationUtil.waitingForRecenter = false;
                ConfigurationUtil.recenterTolerance = 0;
                ConfigurationUtil.recenterPosition = new Vector3(0, 0, 0);
            }

            return;
        }
	}

}
