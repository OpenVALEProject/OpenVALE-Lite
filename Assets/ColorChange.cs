using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    

        public class ColorChange : MonoBehaviour {
                public Color currentColor = Color.red;
                /* 
                void Awake () {
                        // build color
                        Color col = Color.blue;

                        float h, s, v;
                        Color.RGBToHSV(col, out h, out s, out v);
                        //col = Color.HSVToRGB(h, s - 0.25f, v * 4);
                        col = Color.HSVToRGB(h, 0.75f , 10.00f);

                        // set color
                        Renderer renderer = GetComponent<Renderer>();
                        renderer.material.SetColor("_EmissionColor", col);
                        Debug.Log(col);
                }
                */
                public void setColor(Color c){
                        Color col = c;
                        float h, s, v;
                        Color.RGBToHSV(col, out h, out s, out v);
                        //col = Color.HSVToRGB(h, s - 0.25f, v * 4);
                        col = Color.HSVToRGB(h, 0.75f , 7.00f);
                        // set color
                        Renderer renderer = GetComponent<Renderer>();
                        renderer.material.SetColor("_EmissionColor", col);
                }
                private void Update() {
                        //setColor(currentColor);

        
                


                }
        }

