using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTask : MonoBehaviour {

    public UIRotator rotatingDisplay;

    // Start is called before the first frame update
    void Start() {
        rotatingDisplay.setMessage("No valid task selected");
    }

}
