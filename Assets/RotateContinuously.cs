using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContinuously : MonoBehaviour
{
    public bool rotate = true;
    public float degPerSec = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate)
        transform.Rotate(Vector3.up,degPerSec* Time.deltaTime,Space.Self);
    }
}
