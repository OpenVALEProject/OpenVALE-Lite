using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public Canvas twoCanvas;
    public Canvas fourCanvas;
    public GameObject leftInput;
    public GameObject rightInput;
    // Start is called before the first frame update
    public void enableInputDevices(bool enable)
    {
        leftInput.SetActive(enable);
        rightInput.SetActive(enable);
    }
    public void enableNumberPanels(bool enable)
    {
        twoCanvas.gameObject.SetActive(enable);
        fourCanvas.gameObject.SetActive(enable);
    }
    public void enableAVSearchInputs(bool enable)
    {
        enableInputDevices(enable);
        enableNumberPanels(enable);
    }
}
