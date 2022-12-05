using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRButtonDebug : MonoBehaviour
{
    public bool mainTriggerPressed = false;
    public bool palmTriggerPressed = false;
    public bool aPressed = false;
    public bool bPressed = false;
    public float rTrigger;
    private void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch))
        {

            mainTriggerPressed = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {

            mainTriggerPressed = false;
        }

        aPressed = true;
    }
}
