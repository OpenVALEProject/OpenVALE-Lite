using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//  Class for Custom HRTFs 
//  Controls loading, lookup, and unloading

public class CustomHRTF : MonoBehaviour {
	private int hrirSize,numHrirs, hrirLength, min_elevation, max_elevation;
	private string filename;
	private int azStep;
	private int elStep;
	private float[,] leftEarHrirsIP, rightEarHrirsIP;
    private float[] leftEarHrirs, rightEarHrirs;
    private IntPtr lhrir, rhrir;
    private IntPtr[] lhrtf, rhrtf;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Load(){}
	
}
