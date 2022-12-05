using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDControls : MonoBehaviour {

    public GameObject LED1;
    public GameObject LED2;
    public GameObject LED3;
    public GameObject LED4;
    public GameObject centerLED;
    private bool isHighlighted = false;
    private bool isCenterHighlighted = false;
    public Vector3 position;
    public float baseLEDValue = 0.1f;
    LEDControls(double posX, double posY, double posZ) {
        position = new Vector3((float)posX, (float)posY, (float)posZ);
        transform.Translate(position);
    }
  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Move(double posX, double posY, double posZ,float distance = 2.07f) {
        position = new Vector3((float)-posY, (float)posZ, (float)posX);
        transform.Translate(distance * position);
        transform.LookAt(Vector3.zero);
    }
    public void HighlightCenterLED(bool LEDON){
        if(isCenterHighlighted)
            return;
        Color color = Color.red;
        float h, s, v;

        if(LEDON)
        {
            Color.RGBToHSV(color, out h, out s, out v);
            //col = Color.HSVToRGB(h, s - 0.25f, v * 4);
            color = Color.HSVToRGB(h, 0.75f , 7.00f);
        }
        else
        {
            Color.RGBToHSV(color, out h, out s, out v);
            //col = Color.HSVToRGB(h, s - 0.25f, v * 4);
            color = Color.HSVToRGB(h, 0.75f , baseLEDValue);
        }
        centerLED.GetComponent<ColorChange>().currentColor = color;
        centerLED.GetComponent<ColorChange>().setColor(color);
        centerLED.SetActive(LEDON);
        centerLED.GetComponent<ColorChange>().currentColor = color;
        centerLED.GetComponent<ColorChange>().setColor(color);

    }
    public void SetCenterLEDColor(Color c, bool LEDON = true, bool manualSelection = false){
        if(manualSelection){
            if(LEDON)
            {
                isCenterHighlighted = true;
            }
            else{
                isCenterHighlighted = false;
            }
        }
        else 
            if(isCenterHighlighted)
            {
                return;
            }
        
        centerLED.SetActive(true);
        centerLED.GetComponent<ColorChange>().currentColor =c;
        centerLED.GetComponent<ColorChange>().setColor(c);

        centerLED.SetActive(LEDON);
    }
    public void HighlightLEDs(bool LED1ON, bool LED2ON, bool LED3ON, bool LED4ON,bool manualSelection = false)
    {
        
        Color colON = Color.red;

        float h, s, v;
        Color.RGBToHSV(colON, out h, out s, out v);
        //col = Color.HSVToRGB(h, s - 0.25f, v * 4);
        colON = Color.HSVToRGB(h, 0.75f , 1.00f);
        
        Color colOFF = new Color(1,0,0);
        float h1,s1,v1;
        Color.RGBToHSV(colOFF, out h1, out s1, out v1);
        //col = Color.HSVToRGB(h, s - 0.25f, v * 4);
        colOFF = Color.HSVToRGB(h1, 0.75f , baseLEDValue);
        

        if (manualSelection)
        {
            if (LED1ON || LED2ON || LED3ON || LED4ON)
                isHighlighted = true;
            else
                isHighlighted = false;
            

            if (LED1ON)
                LED1.GetComponent<Renderer>().material.SetColor("_EmissionColor", colON);
            else
                LED1.GetComponent<Renderer>().material.SetColor("_EmissionColor", colOFF);
            if (LED2ON)
                LED2.GetComponent<Renderer>().material.SetColor("_EmissionColor", colON);
            else
                LED2.GetComponent<Renderer>().material.SetColor("_EmissionColor", colOFF);
            if (LED3ON)
                LED3.GetComponent<Renderer>().material.SetColor("_EmissionColor", colON);
            else
                LED3.GetComponent<Renderer>().material.SetColor("_EmissionColor", colOFF);
            if (LED4ON)
                LED4.GetComponent<Renderer>().material.SetColor("_EmissionColor", colON);
            else
                LED4.GetComponent<Renderer>().material.SetColor("_EmissionColor", colOFF);

        }
        else {
            if (isHighlighted)
                return;
            if (LED1ON)
                LED1.GetComponent<Renderer>().material.SetColor("_EmissionColor", colON);
            else
                LED1.GetComponent<Renderer>().material.SetColor("_EmissionColor", colOFF);
            if (LED2ON)
                LED2.GetComponent<Renderer>().material.SetColor("_EmissionColor", colON);
            else
                LED2.GetComponent<Renderer>().material.SetColor("_EmissionColor", colOFF);
            if (LED3ON)
                LED3.GetComponent<Renderer>().material.SetColor("_EmissionColor", colON);
            else
                LED3.GetComponent<Renderer>().material.SetColor("_EmissionColor", colOFF);
            if (LED4ON)
                LED4.GetComponent<Renderer>().material.SetColor("_EmissionColor", colON);
            else
                LED4.GetComponent<Renderer>().material.SetColor("_EmissionColor", colOFF);
            
        }

        }
    
        
    
}
