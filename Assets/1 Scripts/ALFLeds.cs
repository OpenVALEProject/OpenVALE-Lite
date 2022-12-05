﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
public class ALFLeds : MonoBehaviour {
    public GameObject speakerPrefab;
    public GameObject indicatorLEDPrefab;
    // Use this for initialization
    public Dictionary<string,GameObject> speakers = new Dictionary<string, GameObject>();
    //List<Vector3> speakerLocation = new List<Vector3>();
     public Dictionary<string,GameObject> LEDString = new Dictionary<string, GameObject>();
    void Awake () {
        if (SceneManager.GetActiveScene().name.ToLower().Equals("openvale")) {
            setupALFLEDs();
        }
        else if(SceneManager.GetActiveScene().name.ToLower().Equals("sharc")){
            setupSHARCLEDs();
            setupLEDString();
        }
    }
    private void setupALFLEDs(){
              
            
        //speakers.Add("1",new LEDControls//speakerLocation.Add(2.08f * new Vector3(0, 0, 0));
        speakers.Add("1", Instantiate(speakerPrefab));
        speakers["1"].GetComponent<LEDControls>().Move(0.183951, -0.982935, 0.000000);
        speakers.Add("2", Instantiate(speakerPrefab));
        speakers["2"].GetComponent<LEDControls>().Move(0.525472, -0.850811, 0.000000);
        speakers.Add("3", Instantiate(speakerPrefab));
        speakers["3"].GetComponent<LEDControls>().Move(0.703395, -0.710799, 0.000000);
        speakers.Add("4", Instantiate(speakerPrefab));
        speakers["4"].GetComponent<LEDControls>().Move(0.848048, -0.529919, 0.000000);
        speakers.Add("5", Instantiate(speakerPrefab));
        speakers["5"].GetComponent<LEDControls>().Move(0.934204, -0.356738, 0.000000);
        speakers.Add("6", Instantiate(speakerPrefab));
        speakers["6"].GetComponent<LEDControls>().Move(0.991216, -0.132256, 0.000000);
        speakers.Add("7", Instantiate(speakerPrefab));
        speakers["7"].GetComponent<LEDControls>().Move(0.991216, 0.132256, 0.000000);
        speakers.Add("8", Instantiate(speakerPrefab));
        speakers["8"].GetComponent<LEDControls>().Move(0.932954, 0.359997, 0.000000);
        speakers.Add("9", Instantiate(speakerPrefab));
        speakers["9"].GetComponent<LEDControls>().Move(0.838671, 0.544639, 0.000000);
        speakers.Add("10", Instantiate(speakerPrefab));
        speakers["10"].GetComponent<LEDControls>().Move(0.703395, 0.710799, 0.000000);
        speakers.Add("11", Instantiate(speakerPrefab));
        speakers["11"].GetComponent<LEDControls>().Move(0.525472, 0.850811, 0.000000);
        speakers.Add("12", Instantiate(speakerPrefab));
        speakers["12"].GetComponent<LEDControls>().Move(0.183951, 0.982935, 0.000000);
        speakers.Add("13", Instantiate(speakerPrefab));
        speakers["13"].GetComponent<LEDControls>().Move(-0.183951, 0.982935, 0.000000);
        speakers.Add("14", Instantiate(speakerPrefab));
        speakers["14"].GetComponent<LEDControls>().Move(-0.525472, 0.850811, 0.000000);
        speakers.Add("15", Instantiate(speakerPrefab));
        speakers["15"].GetComponent<LEDControls>().Move(-0.703395, 0.710799, 0.000000);
        speakers.Add("16", Instantiate(speakerPrefab));
        speakers["16"].GetComponent<LEDControls>().Move(-0.838671, 0.544639, 0.000000);
        speakers.Add("17", Instantiate(speakerPrefab));
        speakers["17"].GetComponent<LEDControls>().Move(-0.934204, 0.356738, 0.000000);
        speakers.Add("18", Instantiate(speakerPrefab));
        speakers["18"].GetComponent<LEDControls>().Move(-0.991216, 0.132256, 0.000000);
        speakers.Add("19", Instantiate(speakerPrefab));
        speakers["19"].GetComponent<LEDControls>().Move(-0.991216, -0.132256, 0.000000);
        speakers.Add("20", Instantiate(speakerPrefab));
        speakers["20"].GetComponent<LEDControls>().Move(-0.934204, -0.356738, 0.000000);
        speakers.Add("21", Instantiate(speakerPrefab));
        speakers["21"].GetComponent<LEDControls>().Move(-0.838671, -0.544639, 0.000000);
        speakers.Add("22", Instantiate(speakerPrefab));
        speakers["22"].GetComponent<LEDControls>().Move(-0.703395, -0.710799, 0.000000);
        speakers.Add("23", Instantiate(speakerPrefab));
        speakers["23"].GetComponent<LEDControls>().Move(-0.525472, -0.850811, 0.000000);
        speakers.Add("24", Instantiate(speakerPrefab));
        speakers["24"].GetComponent<LEDControls>().Move(-0.183951, -0.982935, 0.000000);
        speakers.Add("25", Instantiate(speakerPrefab));
        speakers["25"].GetComponent<LEDControls>().Move(0.000000, -0.183951, 0.982935);
        speakers.Add("26", Instantiate(speakerPrefab));
        speakers["26"].GetComponent<LEDControls>().Move(0.000000, -0.525472, 0.850811);
        speakers.Add("27", Instantiate(speakerPrefab));
        speakers["27"].GetComponent<LEDControls>().Move(0.000000, -0.703395, 0.710799);
        speakers.Add("28", Instantiate(speakerPrefab));
        speakers["28"].GetComponent<LEDControls>().Move(0.000000, -0.840567, 0.541708);
        speakers.Add("29", Instantiate(speakerPrefab));
        speakers["29"].GetComponent<LEDControls>().Move(0.000000, -0.934204, 0.356738);
        speakers.Add("30", Instantiate(speakerPrefab));
        speakers["30"].GetComponent<LEDControls>().Move(0.000000, -0.991216, 0.132256);
        speakers.Add("31", Instantiate(speakerPrefab));
        speakers["31"].GetComponent<LEDControls>().Move(0.000000, -0.991216, -0.132256);
        speakers.Add("32", Instantiate(speakerPrefab));
        speakers["32"].GetComponent<LEDControls>().Move(0.000000, -0.934204, -0.356738);
        speakers.Add("33", Instantiate(speakerPrefab));
        speakers["33"].GetComponent<LEDControls>().Move(0.000000, -0.840567, -0.541708);
        speakers.Add("34", Instantiate(speakerPrefab));
        speakers["34"].GetComponent<LEDControls>().Move(0.000000, -0.703395, -0.710799);
        speakers.Add("35", Instantiate(speakerPrefab));
        speakers["35"].GetComponent<LEDControls>().Move(0.000000, -0.525472, -0.850811);
        speakers.Add("36", Instantiate(speakerPrefab));
        speakers["36"].GetComponent<LEDControls>().Move(0.000000, -0.183951, -0.982935);
        speakers.Add("37", Instantiate(speakerPrefab));
        speakers["37"].GetComponent<LEDControls>().Move(0.000000, 0.183951, -0.982935);
        speakers.Add("38", Instantiate(speakerPrefab));
        speakers["38"].GetComponent<LEDControls>().Move(0.000000, 0.525472, -0.850811);
        speakers.Add("39", Instantiate(speakerPrefab));
        speakers["39"].GetComponent<LEDControls>().Move(0.000000, 0.703395, -0.710799);
        speakers.Add("40", Instantiate(speakerPrefab));
        speakers["40"].GetComponent<LEDControls>().Move(0.000000, 0.840567, -0.541708);
        speakers.Add("41", Instantiate(speakerPrefab));
        speakers["41"].GetComponent<LEDControls>().Move(0.000000, 0.934204, -0.356738);
        speakers.Add("42", Instantiate(speakerPrefab));
        speakers["42"].GetComponent<LEDControls>().Move(0.000000, 0.991216, -0.132256);
        speakers.Add("43", Instantiate(speakerPrefab));
        speakers["43"].GetComponent<LEDControls>().Move(0.000000, 0.991216, 0.132256);
        speakers.Add("44", Instantiate(speakerPrefab));
        speakers["44"].GetComponent<LEDControls>().Move(0.000000, 0.934204, 0.356738);
        speakers.Add("45", Instantiate(speakerPrefab));
        speakers["45"].GetComponent<LEDControls>().Move(0.000000, 0.840567, 0.541708);
        speakers.Add("46", Instantiate(speakerPrefab));
        speakers["46"].GetComponent<LEDControls>().Move(0.000000, 0.703395, 0.710799);
        speakers.Add("47", Instantiate(speakerPrefab));
        speakers["47"].GetComponent<LEDControls>().Move(0.000000, 0.525472, 0.850811);
        speakers.Add("48", Instantiate(speakerPrefab));
        speakers["48"].GetComponent<LEDControls>().Move(0.000000, 0.183951, 0.982935);
        speakers.Add("49", Instantiate(speakerPrefab));
        speakers["49"].GetComponent<LEDControls>().Move(0.132256, -0.000000, 0.991216);
        speakers.Add("50", Instantiate(speakerPrefab));
        speakers["50"].GetComponent<LEDControls>().Move(0.356738, -0.000000, 0.934204);
        speakers.Add("51", Instantiate(speakerPrefab));
        speakers["51"].GetComponent<LEDControls>().Move(0.540240, -0.000000, 0.841511);
        speakers.Add("52", Instantiate(speakerPrefab));
        speakers["52"].GetComponent<LEDControls>().Move(0.710799, -0.000000, 0.703395);
        speakers.Add("53", Instantiate(speakerPrefab));
        speakers["53"].GetComponent<LEDControls>().Move(0.850811, -0.000000, 0.525472);
        speakers.Add("54", Instantiate(speakerPrefab));
        speakers["54"].GetComponent<LEDControls>().Move(0.982935, -0.000000, 0.183951);
        speakers.Add("55", Instantiate(speakerPrefab));
        speakers["55"].GetComponent<LEDControls>().Move(0.982935, -0.000000, -0.183951);
        speakers.Add("56", Instantiate(speakerPrefab));
        speakers["56"].GetComponent<LEDControls>().Move(0.850811, -0.000000, -0.525472);
        speakers.Add("57", Instantiate(speakerPrefab));
        speakers["57"].GetComponent<LEDControls>().Move(0.710799, -0.000000, -0.703395);
        speakers.Add("58", Instantiate(speakerPrefab));
        speakers["58"].GetComponent<LEDControls>().Move(0.540240, -0.000000, -0.841511);
        speakers.Add("59", Instantiate(speakerPrefab));
        speakers["59"].GetComponent<LEDControls>().Move(0.356738, -0.000000, -0.934204);
        speakers.Add("60", Instantiate(speakerPrefab));
        speakers["60"].GetComponent<LEDControls>().Move(0.132256, -0.000000, -0.991216);
        speakers.Add("61", Instantiate(speakerPrefab));
        speakers["61"].GetComponent<LEDControls>().Move(-0.132256, 0.000000, -0.991216);
        speakers.Add("62", Instantiate(speakerPrefab));
        speakers["62"].GetComponent<LEDControls>().Move(-0.356738, 0.000000, -0.934204);
        speakers.Add("63", Instantiate(speakerPrefab));
        speakers["63"].GetComponent<LEDControls>().Move(-0.540240, 0.000000, -0.841511);
        speakers.Add("64", Instantiate(speakerPrefab));
        speakers["64"].GetComponent<LEDControls>().Move(-0.710799, 0.000000, -0.703395);
        speakers.Add("65", Instantiate(speakerPrefab));
        speakers["65"].GetComponent<LEDControls>().Move(-0.850811, 0.000000, -0.525472);
        speakers.Add("66", Instantiate(speakerPrefab));
        speakers["66"].GetComponent<LEDControls>().Move(-0.982935, 0.000000, -0.183951);
        speakers.Add("67", Instantiate(speakerPrefab));
        speakers["67"].GetComponent<LEDControls>().Move(-0.982935, 0.000000, 0.183951);
        speakers.Add("68", Instantiate(speakerPrefab));
        speakers["68"].GetComponent<LEDControls>().Move(-0.850811, 0.000000, 0.525472);
        speakers.Add("69", Instantiate(speakerPrefab));
        speakers["69"].GetComponent<LEDControls>().Move(-0.710799, 0.000000, 0.703395);
        speakers.Add("70", Instantiate(speakerPrefab));
        speakers["70"].GetComponent<LEDControls>().Move(-0.540240, 0.000000, 0.841511);
        speakers.Add("71", Instantiate(speakerPrefab));
        speakers["71"].GetComponent<LEDControls>().Move(-0.356738, 0.000000, 0.934204);
        speakers.Add("72", Instantiate(speakerPrefab));
        speakers["72"].GetComponent<LEDControls>().Move(-0.132256, 0.000000, 0.991216);
        speakers.Add("73", Instantiate(speakerPrefab));
        speakers["73"].GetComponent<LEDControls>().Move(0.132207, -0.357402, 0.924546);
        speakers.Add("74", Instantiate(speakerPrefab));
        speakers["74"].GetComponent<LEDControls>().Move(0.213677, -0.571506, 0.792290);
        speakers.Add("75", Instantiate(speakerPrefab));
        speakers["75"].GetComponent<LEDControls>().Move(0.211768, -0.738522, 0.640110);
        speakers.Add("76", Instantiate(speakerPrefab));
        speakers["76"].GetComponent<LEDControls>().Move(0.198740, -0.867745, 0.455545);
        speakers.Add("77", Instantiate(speakerPrefab));
        speakers["77"].GetComponent<LEDControls>().Move(0.177930, -0.950762, 0.253758);
        speakers.Add("78", Instantiate(speakerPrefab));
        speakers["78"].GetComponent<LEDControls>().Move(0.253132, -0.177245, 0.951057);
        speakers.Add("79", Instantiate(speakerPrefab));
        speakers["79"].GetComponent<LEDControls>().Move(0.343075, -0.396057, 0.851727);
        speakers.Add("80", Instantiate(speakerPrefab));
        speakers["80"].GetComponent<LEDControls>().Move(0.410177, -0.587976, 0.697165);
        speakers.Add("81", Instantiate(speakerPrefab));
        speakers["81"].GetComponent<LEDControls>().Move(0.413199, -0.736312, 0.535827);
        speakers.Add("82", Instantiate(speakerPrefab));
        speakers["82"].GetComponent<LEDControls>().Move(0.395392, -0.851800, 0.343660);
        speakers.Add("83", Instantiate(speakerPrefab));
        speakers["83"].GetComponent<LEDControls>().Move(0.356834, -0.924758, 0.132256);
        speakers.Add("84", Instantiate(speakerPrefab));
        speakers["84"].GetComponent<LEDControls>().Move(0.455060, -0.199758, 0.867765);
        speakers.Add("85", Instantiate(speakerPrefab));
        speakers["85"].GetComponent<LEDControls>().Move(0.527515, -0.424133, 0.736097);
        speakers.Add("86", Instantiate(speakerPrefab));
        speakers["86"].GetComponent<LEDControls>().Move(0.577096, -0.577096, 0.577858);
        speakers.Add("87", Instantiate(speakerPrefab));
        speakers["87"].GetComponent<LEDControls>().Move(0.587518, -0.697700, 0.409923);
        speakers.Add("88", Instantiate(speakerPrefab));
        speakers["88"].GetComponent<LEDControls>().Move(0.571530, -0.792446, 0.213030);
        speakers.Add("89", Instantiate(speakerPrefab));
        speakers["89"].GetComponent<LEDControls>().Move(0.640200, -0.211726, 0.738455);
        speakers.Add("90", Instantiate(speakerPrefab));
        speakers["90"].GetComponent<LEDControls>().Move(0.697073, -0.410607, 0.587785);
        speakers.Add("91", Instantiate(speakerPrefab));
        speakers["91"].GetComponent<LEDControls>().Move(0.735823, -0.536571, 0.413104);
        speakers.Add("92", Instantiate(speakerPrefab));
        speakers["92"].GetComponent<LEDControls>().Move(0.738783, -0.639954, 0.211325);
        speakers.Add("93", Instantiate(speakerPrefab));
        speakers["93"].GetComponent<LEDControls>().Move(0.792797, -0.213913, 0.570714);
        speakers.Add("94", Instantiate(speakerPrefab));
        speakers["94"].GetComponent<LEDControls>().Move(0.852764, -0.341081, 0.395546);
        speakers.Add("95", Instantiate(speakerPrefab));
        speakers["95"].GetComponent<LEDControls>().Move(0.868413, -0.453995, 0.199368);
        speakers.Add("96", Instantiate(speakerPrefab));
        speakers["96"].GetComponent<LEDControls>().Move(0.924885, -0.131631, 0.356738);
        speakers.Add("97", Instantiate(speakerPrefab));
        speakers["97"].GetComponent<LEDControls>().Move(0.951103, -0.253069, 0.177085);
        speakers.Add("98", Instantiate(speakerPrefab));
        speakers["98"].GetComponent<LEDControls>().Move(0.132207, 0.357402, 0.924546);
        speakers.Add("99", Instantiate(speakerPrefab));
        speakers["99"].GetComponent<LEDControls>().Move(0.213677, 0.571506, 0.792290);
        speakers.Add("100", Instantiate(speakerPrefab));
        speakers["100"].GetComponent<LEDControls>().Move(0.211768, 0.738522, 0.640110);
        speakers.Add("101", Instantiate(speakerPrefab));
        speakers["101"].GetComponent<LEDControls>().Move(0.198740, 0.867745, 0.455545);
        speakers.Add("102", Instantiate(speakerPrefab));
        speakers["102"].GetComponent<LEDControls>().Move(0.177930, 0.950762, 0.253758);
        speakers.Add("103", Instantiate(speakerPrefab));
        speakers["103"].GetComponent<LEDControls>().Move(0.253132, 0.177245, 0.951057);
        speakers.Add("104", Instantiate(speakerPrefab));
        speakers["104"].GetComponent<LEDControls>().Move(0.343075, 0.396057, 0.851727);
        speakers.Add("105", Instantiate(speakerPrefab));
        speakers["105"].GetComponent<LEDControls>().Move(0.410177, 0.587976, 0.697165);
        speakers.Add("106", Instantiate(speakerPrefab));
        speakers["106"].GetComponent<LEDControls>().Move(0.413199, 0.736312, 0.535827);
        speakers.Add("107", Instantiate(speakerPrefab));
        speakers["107"].GetComponent<LEDControls>().Move(0.395392, 0.851800, 0.343660);
        speakers.Add("108", Instantiate(speakerPrefab));
        speakers["108"].GetComponent<LEDControls>().Move(0.356834, 0.924758, 0.132256);
        speakers.Add("109", Instantiate(speakerPrefab));
        speakers["109"].GetComponent<LEDControls>().Move(0.455060, 0.199758, 0.867765);
        speakers.Add("110", Instantiate(speakerPrefab));
        speakers["110"].GetComponent<LEDControls>().Move(0.527515, 0.424133, 0.736097);
        speakers.Add("111", Instantiate(speakerPrefab));
        speakers["111"].GetComponent<LEDControls>().Move(0.577096, 0.577096, 0.577858);
        speakers.Add("112", Instantiate(speakerPrefab));
        speakers["112"].GetComponent<LEDControls>().Move(0.587518, 0.697700, 0.409923);
        speakers.Add("113", Instantiate(speakerPrefab));
        speakers["113"].GetComponent<LEDControls>().Move(0.571530, 0.792446, 0.213030);
        speakers.Add("114", Instantiate(speakerPrefab));
        speakers["114"].GetComponent<LEDControls>().Move(0.640200, 0.211726, 0.738455);
        speakers.Add("115", Instantiate(speakerPrefab));
        speakers["115"].GetComponent<LEDControls>().Move(0.697073, 0.410607, 0.587785);
        speakers.Add("116", Instantiate(speakerPrefab));
        speakers["116"].GetComponent<LEDControls>().Move(0.735823, 0.536571, 0.413104);
        speakers.Add("117", Instantiate(speakerPrefab));
        speakers["117"].GetComponent<LEDControls>().Move(0.738783, 0.639954, 0.211325);
        speakers.Add("118", Instantiate(speakerPrefab));
        speakers["118"].GetComponent<LEDControls>().Move(0.792797, 0.213913, 0.570714);
        speakers.Add("119", Instantiate(speakerPrefab));
        speakers["119"].GetComponent<LEDControls>().Move(0.852764, 0.341081, 0.395546);
        speakers.Add("120", Instantiate(speakerPrefab));
        speakers["120"].GetComponent<LEDControls>().Move(0.868413, 0.453995, 0.199368);
        speakers.Add("121", Instantiate(speakerPrefab));
        speakers["121"].GetComponent<LEDControls>().Move(0.924885, 0.131631, 0.356738);
        speakers.Add("122", Instantiate(speakerPrefab));
        speakers["122"].GetComponent<LEDControls>().Move(0.951103, 0.253069, 0.177085);
        speakers.Add("123", Instantiate(speakerPrefab));
        speakers["123"].GetComponent<LEDControls>().Move(-0.132207, 0.357402, 0.924546);
        speakers.Add("124", Instantiate(speakerPrefab));
        speakers["124"].GetComponent<LEDControls>().Move(-0.213677, 0.571506, 0.792290);
        speakers.Add("125", Instantiate(speakerPrefab));
        speakers["125"].GetComponent<LEDControls>().Move(-0.211768, 0.738522, 0.640110);
        speakers.Add("126", Instantiate(speakerPrefab));
        speakers["126"].GetComponent<LEDControls>().Move(-0.198740, 0.867745, 0.455545);
        speakers.Add("127", Instantiate(speakerPrefab));
        speakers["127"].GetComponent<LEDControls>().Move(-0.177930, 0.950762, 0.253758);
        speakers.Add("128", Instantiate(speakerPrefab));
        speakers["128"].GetComponent<LEDControls>().Move(-0.253132, 0.177245, 0.951057);
        speakers.Add("129", Instantiate(speakerPrefab));
        speakers["129"].GetComponent<LEDControls>().Move(-0.343075, 0.396057, 0.851727);
        speakers.Add("130", Instantiate(speakerPrefab));
        speakers["130"].GetComponent<LEDControls>().Move(-0.410177, 0.587976, 0.697165);
        speakers.Add("131", Instantiate(speakerPrefab));
        speakers["131"].GetComponent<LEDControls>().Move(-0.413199, 0.736312, 0.535827);
        speakers.Add("132", Instantiate(speakerPrefab));
        speakers["132"].GetComponent<LEDControls>().Move(-0.395392, 0.851800, 0.343660);
        speakers.Add("133", Instantiate(speakerPrefab));
        speakers["133"].GetComponent<LEDControls>().Move(-0.356834, 0.924758, 0.132256);
        speakers.Add("134", Instantiate(speakerPrefab));
        speakers["134"].GetComponent<LEDControls>().Move(-0.455060, 0.199758, 0.867765);
        speakers.Add("135", Instantiate(speakerPrefab));
        speakers["135"].GetComponent<LEDControls>().Move(-0.527515, 0.424133, 0.736097);
        speakers.Add("136", Instantiate(speakerPrefab));
        speakers["136"].GetComponent<LEDControls>().Move(-0.577096, 0.577096, 0.577858);
        speakers.Add("137", Instantiate(speakerPrefab));
        speakers["137"].GetComponent<LEDControls>().Move(-0.587518, 0.697700, 0.409923);
        speakers.Add("138", Instantiate(speakerPrefab));
        speakers["138"].GetComponent<LEDControls>().Move(-0.571530, 0.792446, 0.213030);
        speakers.Add("139", Instantiate(speakerPrefab));
        speakers["139"].GetComponent<LEDControls>().Move(-0.640200, 0.211726, 0.738455);
        speakers.Add("140", Instantiate(speakerPrefab));
        speakers["140"].GetComponent<LEDControls>().Move(-0.697073, 0.410607, 0.587785);
        speakers.Add("141", Instantiate(speakerPrefab));
        speakers["141"].GetComponent<LEDControls>().Move(-0.735823, 0.536571, 0.413104);
        speakers.Add("142", Instantiate(speakerPrefab));
        speakers["142"].GetComponent<LEDControls>().Move(-0.738783, 0.639954, 0.211325);
        speakers.Add("143", Instantiate(speakerPrefab));
        speakers["143"].GetComponent<LEDControls>().Move(-0.792797, 0.213913, 0.570714);
        speakers.Add("144", Instantiate(speakerPrefab));
        speakers["144"].GetComponent<LEDControls>().Move(-0.852764, 0.341081, 0.395546);
        speakers.Add("145", Instantiate(speakerPrefab));
        speakers["145"].GetComponent<LEDControls>().Move(-0.868413, 0.453995, 0.199368);
        speakers.Add("146", Instantiate(speakerPrefab));
        speakers["146"].GetComponent<LEDControls>().Move(-0.924885, 0.131631, 0.356738);
        speakers.Add("147", Instantiate(speakerPrefab));
        speakers["147"].GetComponent<LEDControls>().Move(-0.951103, 0.253069, 0.177085);
        speakers.Add("148", Instantiate(speakerPrefab));
        speakers["148"].GetComponent<LEDControls>().Move(-0.132207, -0.357402, 0.924546);
        speakers.Add("149", Instantiate(speakerPrefab));
        speakers["149"].GetComponent<LEDControls>().Move(-0.213677, -0.571506, 0.792290);
        speakers.Add("150", Instantiate(speakerPrefab));
        speakers["150"].GetComponent<LEDControls>().Move(-0.211768, -0.738522, 0.640110);
        speakers.Add("151", Instantiate(speakerPrefab));
        speakers["151"].GetComponent<LEDControls>().Move(-0.198740, -0.867745, 0.455545);
        speakers.Add("152", Instantiate(speakerPrefab));
        speakers["152"].GetComponent<LEDControls>().Move(-0.177930, -0.950762, 0.253758);
        speakers.Add("153", Instantiate(speakerPrefab));
        speakers["153"].GetComponent<LEDControls>().Move(-0.253132, -0.177245, 0.951057);
        speakers.Add("154", Instantiate(speakerPrefab));
        speakers["154"].GetComponent<LEDControls>().Move(-0.343075, -0.396057, 0.851727);
        speakers.Add("155", Instantiate(speakerPrefab));
        speakers["155"].GetComponent<LEDControls>().Move(-0.410177, -0.587976, 0.697165);
        speakers.Add("156", Instantiate(speakerPrefab));
        speakers["156"].GetComponent<LEDControls>().Move(-0.413199, -0.736312, 0.535827);
        speakers.Add("157", Instantiate(speakerPrefab));
        speakers["157"].GetComponent<LEDControls>().Move(-0.395392, -0.851800, 0.343660);
        speakers.Add("158", Instantiate(speakerPrefab));
        speakers["158"].GetComponent<LEDControls>().Move(-0.356834, -0.924758, 0.132256);
        speakers.Add("159", Instantiate(speakerPrefab));
        speakers["159"].GetComponent<LEDControls>().Move(-0.455060, -0.199758, 0.867765);
        speakers.Add("160", Instantiate(speakerPrefab));
        speakers["160"].GetComponent<LEDControls>().Move(-0.527515, -0.424133, 0.736097);
        speakers.Add("161", Instantiate(speakerPrefab));
        speakers["161"].GetComponent<LEDControls>().Move(-0.577096, -0.577096, 0.577858);
        speakers.Add("162", Instantiate(speakerPrefab));
        speakers["162"].GetComponent<LEDControls>().Move(-0.587518, -0.697700, 0.409923);
        speakers.Add("163", Instantiate(speakerPrefab));
        speakers["163"].GetComponent<LEDControls>().Move(-0.571530, -0.792446, 0.213030);
        speakers.Add("164", Instantiate(speakerPrefab));
        speakers["164"].GetComponent<LEDControls>().Move(-0.640200, -0.211726, 0.738455);
        speakers.Add("165", Instantiate(speakerPrefab));
        speakers["165"].GetComponent<LEDControls>().Move(-0.697073, -0.410607, 0.587785);
        speakers.Add("166", Instantiate(speakerPrefab));
        speakers["166"].GetComponent<LEDControls>().Move(-0.735823, -0.536571, 0.413104);
        speakers.Add("167", Instantiate(speakerPrefab));
        speakers["167"].GetComponent<LEDControls>().Move(-0.738783, -0.639954, 0.211325);
        speakers.Add("168", Instantiate(speakerPrefab));
        speakers["168"].GetComponent<LEDControls>().Move(-0.792797, -0.213913, 0.570714);
        speakers.Add("169", Instantiate(speakerPrefab));
        speakers["169"].GetComponent<LEDControls>().Move(-0.852764, -0.341081, 0.395546);
        speakers.Add("170", Instantiate(speakerPrefab));
        speakers["170"].GetComponent<LEDControls>().Move(-0.868413, -0.453995, 0.199368);
        speakers.Add("171", Instantiate(speakerPrefab));
        speakers["171"].GetComponent<LEDControls>().Move(-0.924885, -0.131631, 0.356738);
        speakers.Add("172", Instantiate(speakerPrefab));
        speakers["172"].GetComponent<LEDControls>().Move(-0.951103, -0.253069, 0.177085);
        speakers.Add("173", Instantiate(speakerPrefab));
        speakers["173"].GetComponent<LEDControls>().Move(0.177930, -0.950762, -0.253758);
        speakers.Add("174", Instantiate(speakerPrefab));
        speakers["174"].GetComponent<LEDControls>().Move(0.198740, -0.867745, -0.455545);
        speakers.Add("175", Instantiate(speakerPrefab));
        speakers["175"].GetComponent<LEDControls>().Move(0.211768, -0.738522, -0.640110);
        speakers.Add("176", Instantiate(speakerPrefab));
        speakers["176"].GetComponent<LEDControls>().Move(0.213677, -0.571506, -0.792290);
        speakers.Add("177", Instantiate(speakerPrefab));
        speakers["177"].GetComponent<LEDControls>().Move(0.132207, -0.357402, -0.924546);
        speakers.Add("178", Instantiate(speakerPrefab));
        speakers["178"].GetComponent<LEDControls>().Move(0.356834, -0.924758, -0.132256);
        speakers.Add("179", Instantiate(speakerPrefab));
        speakers["179"].GetComponent<LEDControls>().Move(0.395392, -0.851800, -0.343660);
        speakers.Add("180", Instantiate(speakerPrefab));
        speakers["180"].GetComponent<LEDControls>().Move(0.413199, -0.736312, -0.535827);
        speakers.Add("181", Instantiate(speakerPrefab));
        speakers["181"].GetComponent<LEDControls>().Move(0.410177, -0.587976, -0.697165);
        speakers.Add("182", Instantiate(speakerPrefab));
        speakers["182"].GetComponent<LEDControls>().Move(0.343075, -0.396057, -0.851727);
        speakers.Add("183", Instantiate(speakerPrefab));
        speakers["183"].GetComponent<LEDControls>().Move(0.253132, -0.177245, -0.951057);
        speakers.Add("184", Instantiate(speakerPrefab));
        speakers["184"].GetComponent<LEDControls>().Move(0.571530, -0.792446, -0.213030);
        speakers.Add("185", Instantiate(speakerPrefab));
        speakers["185"].GetComponent<LEDControls>().Move(0.587518, -0.697700, -0.409923);
        speakers.Add("186", Instantiate(speakerPrefab));
        speakers["186"].GetComponent<LEDControls>().Move(0.577096, -0.577096, -0.577858);
        speakers.Add("187", Instantiate(speakerPrefab));
        speakers["187"].GetComponent<LEDControls>().Move(0.527515, -0.424133, -0.736097);
        speakers.Add("188", Instantiate(speakerPrefab));
        speakers["188"].GetComponent<LEDControls>().Move(0.456100, -0.197372, -0.867765);
        speakers.Add("189", Instantiate(speakerPrefab));
        speakers["189"].GetComponent<LEDControls>().Move(0.738783, -0.639954, -0.211325);
        speakers.Add("190", Instantiate(speakerPrefab));
        speakers["190"].GetComponent<LEDControls>().Move(0.735823, -0.536571, -0.413104);
        speakers.Add("191", Instantiate(speakerPrefab));
        speakers["191"].GetComponent<LEDControls>().Move(0.697073, -0.410607, -0.587785);
        speakers.Add("192", Instantiate(speakerPrefab));
        speakers["192"].GetComponent<LEDControls>().Move(0.640200, -0.211726, -0.738455);
        speakers.Add("193", Instantiate(speakerPrefab));
        speakers["193"].GetComponent<LEDControls>().Move(0.868413, -0.453995, -0.199368);
        speakers.Add("194", Instantiate(speakerPrefab));
        speakers["194"].GetComponent<LEDControls>().Move(0.853404, -0.341337, -0.393942);
        speakers.Add("195", Instantiate(speakerPrefab));
        speakers["195"].GetComponent<LEDControls>().Move(0.792797, -0.213913, -0.570714);
        speakers.Add("196", Instantiate(speakerPrefab));
        speakers["196"].GetComponent<LEDControls>().Move(0.951103, -0.253069, -0.177085);
        speakers.Add("197", Instantiate(speakerPrefab));
        speakers["197"].GetComponent<LEDControls>().Move(0.924885, -0.131631, -0.356738);
        speakers.Add("198", Instantiate(speakerPrefab));
        speakers["198"].GetComponent<LEDControls>().Move(0.177930, 0.950762, -0.253758);
        speakers.Add("199", Instantiate(speakerPrefab));
        speakers["199"].GetComponent<LEDControls>().Move(0.198740, 0.867745, -0.455545);
        speakers.Add("200", Instantiate(speakerPrefab));
        speakers["200"].GetComponent<LEDControls>().Move(0.211768, 0.738522, -0.640110);
        speakers.Add("201", Instantiate(speakerPrefab));
        speakers["201"].GetComponent<LEDControls>().Move(0.213677, 0.571506, -0.792290);
        speakers.Add("202", Instantiate(speakerPrefab));
        speakers["202"].GetComponent<LEDControls>().Move(0.132207, 0.357402, -0.924546);
        speakers.Add("203", Instantiate(speakerPrefab));
        speakers["203"].GetComponent<LEDControls>().Move(0.356834, 0.924758, -0.132256);
        speakers.Add("204", Instantiate(speakerPrefab));
        speakers["204"].GetComponent<LEDControls>().Move(0.395392, 0.851800, -0.343660);
        speakers.Add("205", Instantiate(speakerPrefab));
        speakers["205"].GetComponent<LEDControls>().Move(0.413199, 0.736312, -0.535827);
        speakers.Add("206", Instantiate(speakerPrefab));
        speakers["206"].GetComponent<LEDControls>().Move(0.410177, 0.587976, -0.697165);
        speakers.Add("207", Instantiate(speakerPrefab));
        speakers["207"].GetComponent<LEDControls>().Move(0.343075, 0.396057, -0.851727);
        speakers.Add("208", Instantiate(speakerPrefab));
        speakers["208"].GetComponent<LEDControls>().Move(0.253132, 0.177245, -0.951057);
        speakers.Add("209", Instantiate(speakerPrefab));
        speakers["209"].GetComponent<LEDControls>().Move(0.571530, 0.792446, -0.213030);
        speakers.Add("210", Instantiate(speakerPrefab));
        speakers["210"].GetComponent<LEDControls>().Move(0.587518, 0.697700, -0.409923);
        speakers.Add("211", Instantiate(speakerPrefab));
        speakers["211"].GetComponent<LEDControls>().Move(0.577096, 0.577096, -0.577858);
        speakers.Add("212", Instantiate(speakerPrefab));
        speakers["212"].GetComponent<LEDControls>().Move(0.527515, 0.424133, -0.736097);
        speakers.Add("213", Instantiate(speakerPrefab));
        speakers["213"].GetComponent<LEDControls>().Move(0.455060, 0.199758, -0.867765);
        speakers.Add("214", Instantiate(speakerPrefab));
        speakers["214"].GetComponent<LEDControls>().Move(0.738783, 0.639954, -0.211325);
        speakers.Add("215", Instantiate(speakerPrefab));
        speakers["215"].GetComponent<LEDControls>().Move(0.735823, 0.536571, -0.413104);
        speakers.Add("216", Instantiate(speakerPrefab));
        speakers["216"].GetComponent<LEDControls>().Move(0.697073, 0.410607, -0.587785);
        speakers.Add("217", Instantiate(speakerPrefab));
        speakers["217"].GetComponent<LEDControls>().Move(0.640200, 0.211726, -0.738455);
        speakers.Add("218", Instantiate(speakerPrefab));
        speakers["218"].GetComponent<LEDControls>().Move(0.868413, 0.453995, -0.199368);
        speakers.Add("219", Instantiate(speakerPrefab));
        speakers["219"].GetComponent<LEDControls>().Move(0.852764, 0.341081, -0.395546);
        speakers.Add("220", Instantiate(speakerPrefab));
        speakers["220"].GetComponent<LEDControls>().Move(0.792797, 0.213913, -0.570714);
        speakers.Add("221", Instantiate(speakerPrefab));
        speakers["221"].GetComponent<LEDControls>().Move(0.951103, 0.253069, -0.177085);
        speakers.Add("222", Instantiate(speakerPrefab));
        speakers["222"].GetComponent<LEDControls>().Move(0.924885, 0.131631, -0.356738);
        speakers.Add("223", Instantiate(speakerPrefab));
        speakers["223"].GetComponent<LEDControls>().Move(-0.177930, 0.950762, -0.253758);
        speakers.Add("224", Instantiate(speakerPrefab));
        speakers["224"].GetComponent<LEDControls>().Move(-0.198740, 0.867745, -0.455545);
        speakers.Add("225", Instantiate(speakerPrefab));
        speakers["225"].GetComponent<LEDControls>().Move(-0.211768, 0.738522, -0.640110);
        speakers.Add("226", Instantiate(speakerPrefab));
        speakers["226"].GetComponent<LEDControls>().Move(-0.213677, 0.571506, -0.792290);
        speakers.Add("227", Instantiate(speakerPrefab));
        speakers["227"].GetComponent<LEDControls>().Move(-0.132207, 0.357402, -0.924546);
        speakers.Add("228", Instantiate(speakerPrefab));
        speakers["228"].GetComponent<LEDControls>().Move(-0.356834, 0.924758, -0.132256);
        speakers.Add("229", Instantiate(speakerPrefab));
        speakers["229"].GetComponent<LEDControls>().Move(-0.395392, 0.851800, -0.343660);
        speakers.Add("230", Instantiate(speakerPrefab));
        speakers["230"].GetComponent<LEDControls>().Move(-0.413199, 0.736312, -0.535827);
        speakers.Add("231", Instantiate(speakerPrefab));
        speakers["231"].GetComponent<LEDControls>().Move(-0.410177, 0.587976, -0.697165);
        speakers.Add("232", Instantiate(speakerPrefab));
        speakers["232"].GetComponent<LEDControls>().Move(-0.343075, 0.396057, -0.851727);
        speakers.Add("233", Instantiate(speakerPrefab));
        speakers["233"].GetComponent<LEDControls>().Move(-0.253132, 0.177245, -0.951057);
        speakers.Add("234", Instantiate(speakerPrefab));
        speakers["234"].GetComponent<LEDControls>().Move(-0.571530, 0.792446, -0.213030);
        speakers.Add("235", Instantiate(speakerPrefab));
        speakers["235"].GetComponent<LEDControls>().Move(-0.587518, 0.697700, -0.409923);
        speakers.Add("236", Instantiate(speakerPrefab));
        speakers["236"].GetComponent<LEDControls>().Move(-0.577096, 0.577096, -0.577858);
        speakers.Add("237", Instantiate(speakerPrefab));
        speakers["237"].GetComponent<LEDControls>().Move(-0.527515, 0.424133, -0.736097);
        speakers.Add("238", Instantiate(speakerPrefab));
        speakers["238"].GetComponent<LEDControls>().Move(-0.456100, 0.197372, -0.867765);
        speakers.Add("239", Instantiate(speakerPrefab));
        speakers["239"].GetComponent<LEDControls>().Move(-0.738783, 0.639954, -0.211325);
        speakers.Add("240", Instantiate(speakerPrefab));
        speakers["240"].GetComponent<LEDControls>().Move(-0.735823, 0.536571, -0.413104);
        speakers.Add("241", Instantiate(speakerPrefab));
        speakers["241"].GetComponent<LEDControls>().Move(-0.697073, 0.410607, -0.587785);
        speakers.Add("242", Instantiate(speakerPrefab));
        speakers["242"].GetComponent<LEDControls>().Move(-0.640200, 0.211726, -0.738455);
        speakers.Add("243", Instantiate(speakerPrefab));
        speakers["243"].GetComponent<LEDControls>().Move(-0.868413, 0.453995, -0.199368);
        speakers.Add("244", Instantiate(speakerPrefab));
        speakers["244"].GetComponent<LEDControls>().Move(-0.853404, 0.341337, -0.393942);
        speakers.Add("245", Instantiate(speakerPrefab));
        speakers["245"].GetComponent<LEDControls>().Move(-0.792797, 0.213913, -0.570714);
        speakers.Add("246", Instantiate(speakerPrefab));
        speakers["246"].GetComponent<LEDControls>().Move(-0.951103, 0.253069, -0.177085);
        speakers.Add("247", Instantiate(speakerPrefab));
        speakers["247"].GetComponent<LEDControls>().Move(-0.924885, 0.131631, -0.356738);
        speakers.Add("248", Instantiate(speakerPrefab));
        speakers["248"].GetComponent<LEDControls>().Move(-0.177930, -0.950762, -0.253758);
        speakers.Add("249", Instantiate(speakerPrefab));
        speakers["249"].GetComponent<LEDControls>().Move(-0.198740, -0.867745, -0.455545);
        speakers.Add("250", Instantiate(speakerPrefab));
        speakers["250"].GetComponent<LEDControls>().Move(-0.211768, -0.738522, -0.640110);
        speakers.Add("251", Instantiate(speakerPrefab));
        speakers["251"].GetComponent<LEDControls>().Move(-0.213677, -0.571506, -0.792290);
        speakers.Add("252", Instantiate(speakerPrefab));
        speakers["252"].GetComponent<LEDControls>().Move(-0.132207, -0.357402, -0.924546);
        speakers.Add("253", Instantiate(speakerPrefab));
        speakers["253"].GetComponent<LEDControls>().Move(-0.356834, -0.924758, -0.132256);
        speakers.Add("254", Instantiate(speakerPrefab));
        speakers["254"].GetComponent<LEDControls>().Move(-0.395392, -0.851800, -0.343660);
        speakers.Add("255", Instantiate(speakerPrefab));
        speakers["255"].GetComponent<LEDControls>().Move(-0.413199, -0.736312, -0.535827);
        speakers.Add("256", Instantiate(speakerPrefab));
        speakers["256"].GetComponent<LEDControls>().Move(-0.410177, -0.587976, -0.697165);
        speakers.Add("257", Instantiate(speakerPrefab));
        speakers["257"].GetComponent<LEDControls>().Move(-0.343075, -0.396057, -0.851727);
        speakers.Add("258", Instantiate(speakerPrefab));
        speakers["258"].GetComponent<LEDControls>().Move(-0.253132, -0.177245, -0.951057);
        speakers.Add("259", Instantiate(speakerPrefab));
        speakers["259"].GetComponent<LEDControls>().Move(-0.571530, -0.792446, -0.213030);
        speakers.Add("260", Instantiate(speakerPrefab));
        speakers["260"].GetComponent<LEDControls>().Move(-0.587518, -0.697700, -0.409923);
        speakers.Add("261", Instantiate(speakerPrefab));
        speakers["261"].GetComponent<LEDControls>().Move(-0.577096, -0.577096, -0.577858);
        speakers.Add("262", Instantiate(speakerPrefab));
        speakers["262"].GetComponent<LEDControls>().Move(-0.527515, -0.424133, -0.736097);
        speakers.Add("263", Instantiate(speakerPrefab));
        speakers["263"].GetComponent<LEDControls>().Move(-0.455060, -0.199758, -0.867765);
        speakers.Add("264", Instantiate(speakerPrefab));
        speakers["264"].GetComponent<LEDControls>().Move(-0.738783, -0.639954, -0.211325);
        speakers.Add("265", Instantiate(speakerPrefab));
        speakers["265"].GetComponent<LEDControls>().Move(-0.735823, -0.536571, -0.413104);
        speakers.Add("266", Instantiate(speakerPrefab));
        speakers["266"].GetComponent<LEDControls>().Move(-0.697073, -0.410607, -0.587785);
        speakers.Add("267", Instantiate(speakerPrefab));
        speakers["267"].GetComponent<LEDControls>().Move(-0.640200, -0.211726, -0.738455);
        speakers.Add("268", Instantiate(speakerPrefab));
        speakers["268"].GetComponent<LEDControls>().Move(-0.868413, -0.453995, -0.199368);
        speakers.Add("269", Instantiate(speakerPrefab));
        speakers["269"].GetComponent<LEDControls>().Move(-0.852764, -0.341081, -0.395546);
        speakers.Add("270", Instantiate(speakerPrefab));
        speakers["270"].GetComponent<LEDControls>().Move(-0.792797, -0.213913, -0.570714);
        speakers.Add("271", Instantiate(speakerPrefab));
        speakers["271"].GetComponent<LEDControls>().Move(-0.951103, -0.253069, -0.177085);
        speakers.Add("272", Instantiate(speakerPrefab));
        speakers["272"].GetComponent<LEDControls>().Move(-0.924885, -0.131631, -0.356738);
        speakers.Add("273", Instantiate(speakerPrefab));
        speakers["273"].GetComponent<LEDControls>().Move(0.000000, -1.000000, 0.000000);
        speakers.Add("274", Instantiate(speakerPrefab));
        speakers["274"].GetComponent<LEDControls>().Move(1.000000, -0.000000, 0.000000);
        speakers.Add("275", Instantiate(speakerPrefab));
        speakers["275"].GetComponent<LEDControls>().Move(0.000000, 1.000000, 0.000000);
        speakers.Add("276", Instantiate(speakerPrefab));
        speakers["276"].GetComponent<LEDControls>().Move(-1.000000, 0.000000, 0.000000);
        speakers.Add("277", Instantiate(speakerPrefab));
        speakers["277"].GetComponent<LEDControls>().Move(0.000000, -0.000000, 1.000000);
        
    }
    private void setupSHARCLEDs(){
        float x;
        float z;
        
        int counter = 0;
        ConstraintSource c = new ConstraintSource();
        c.sourceTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        c.weight = 1.0f;

        for(int i = 0 ; i <360; i+=10){
            z = Mathf.Cos(i* Mathf.Deg2Rad);
            x = Mathf.Sin(i* Mathf.Deg2Rad);
            speakers.Add(counter.ToString(), Instantiate(speakerPrefab));
            speakers[counter.ToString()].GetComponent<LEDControls>().Move(z, x, 0.0,0.93f);
            //speakers[counter.ToString()].GetComponent<LEDControls>().centerLED.GetComponent<UnityEngine.Animations.LookAtConstraint>().AddSource(c);
            //speakers[counter.ToString()].GetComponent<LEDControls>().centerLED.SetActive(false);
            counter++;
            

        }
    }
    private void setupLEDString(){
        float x;
        float z;
        int counter = 1;
        ConstraintSource c = new ConstraintSource();
        c.sourceTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        c.weight = 1.0f;

        for(float i = 0 ; i <360; i+=0.5f){
            z = Mathf.Cos(i* Mathf.Deg2Rad);
            x = Mathf.Sin(i* Mathf.Deg2Rad);
            
            LEDString.Add(counter.ToString(), Instantiate(indicatorLEDPrefab));
            Vector3 newPosition = new Vector3(z, x, 0.0f);
            newPosition = newPosition.normalized * 0.93f;
            LEDString[counter.ToString()].GetComponent<LEDControls>().Move(z, x, 0.0,0.90f);
            LEDString[counter.ToString()].GetComponent<UnityEngine.Animations.LookAtConstraint>().AddSource(c);
            //LEDString[counter.ToString()].SetActive(false);
            counter++;
            

        }
    }
    public GameObject getNearestSpeaker(Vector3 position) {
        GameObject nearest = null;
        float distance = 100f;
        float currentObjectDistance = 0;
        foreach (GameObject speakerLocation in GetComponent<ALFLeds>().speakers.Values)
        {
            currentObjectDistance = (speakerLocation.transform.position - position).magnitude;
            if (currentObjectDistance < distance)
            {
                nearest = speakerLocation;
                distance = currentObjectDistance;
            }
        }
        return nearest;
    }
    public GameObject getNearestLED(Vector3 position) {
        GameObject nearest = null;
        float distance = 100f;
        float currentObjectDistance = 0;
        foreach (GameObject speakerLocation in GetComponent<ALFLeds>().LEDString.Values)
        {
            currentObjectDistance = (speakerLocation.transform.position - position).magnitude;
            if (currentObjectDistance < distance)
            {
                nearest = speakerLocation;
                distance = currentObjectDistance;
            }
        }
        return nearest;
    }
    public string getNearestSpeakerID(Vector3 position)
    {
        string nearest = null;
        float distance = 100f;
        float currentObjectDistance = 0;
        foreach (string speakerLocation in speakers.Keys)
        {
            currentObjectDistance = (speakers[speakerLocation].transform.position - position).magnitude;
            if (currentObjectDistance < distance)
            {
                nearest = speakerLocation;
                distance = currentObjectDistance;
            }
        }
        return nearest;
    }
    public string getNearestLEDID(Vector3 position) {
        string nearest = null;
        float distance = 100f;
        float currentObjectDistance = 0;
        foreach (string speakerLocation in LEDString.Keys)
        {
            currentObjectDistance = (LEDString[speakerLocation].transform.position - position).magnitude;
            if (currentObjectDistance < distance)
            {
                nearest = speakerLocation;
                distance = currentObjectDistance;
            }
        }
        return nearest;
    }
    
    public GameObject getSpeakerByID(string ID) {
        GameObject returnObject;
        if (speakers.TryGetValue(ID, out returnObject)){
            return returnObject;

        }
        return null;

    }
    public GameObject getLEDByID(string ID) {
       
        GameObject returnObject;
        if (LEDString.TryGetValue(ID, out returnObject)){
            return returnObject;

        }
        return null;

    }
    public void resetSpeakerRing(List<int> activeSpeakers){
        float x;
        float z;

        GameObject toBeRemoved;
        foreach (string speakerLocation in speakers.Keys)
        {
            toBeRemoved = speakers[speakerLocation];
            //speakers[speakerLocation] = null;
            Destroy(toBeRemoved);
            

        }
        speakers.Clear();
        int counter = 1;
        ConstraintSource c = new ConstraintSource();
        c.sourceTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        c.weight = 1.0f;
        foreach(int speaker in activeSpeakers){
            float degLocation = (speaker - 1) * 10;
            //degLocation = -degLocation;
            z = Mathf.Cos(degLocation * Mathf.Deg2Rad);
            x = Mathf.Sin(degLocation * Mathf.Deg2Rad);
            speakers.Add(speaker.ToString(), Instantiate(speakerPrefab));
            speakers[speaker.ToString()].GetComponent<LEDControls>().Move(z, x, 0.0,0.93f);
            speakers[speaker.ToString()].GetComponent<LEDControls>().centerLED.GetComponent<UnityEngine.Animations.LookAtConstraint>().AddSource(c);
            speakers[speaker.ToString()].GetComponent<LEDControls>().centerLED.SetActive(false);
            if(speakers[speaker.ToString()].GetComponent<LEDControls>().LED1== null)
                UnityEngine.Debug.Log("NULL");
            counter++;
        }
    }
    public void resetSpeakerRing(int numberSpeakers, float startingLocation = 0.0f){
        float x;
        float z;
        GameObject toBeRemoved;
        foreach (string speakerLocation in speakers.Keys)
        {
            toBeRemoved = speakers[speakerLocation];
            //speakers[speakerLocation] = null;
            Destroy(toBeRemoved);
            

        }
        speakers.Clear();
        int counter = 0;
        ConstraintSource c = new ConstraintSource();
        c.sourceTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        c.weight = 1.0f;
        float stepValue = 360/numberSpeakers;
        for(float i = startingLocation ; i <startingLocation + 360; i+=stepValue){
            z = Mathf.Cos(i* Mathf.Deg2Rad);
            x = Mathf.Sin(i* Mathf.Deg2Rad);
            speakers.Add(counter.ToString(), Instantiate(speakerPrefab));
            speakers[counter.ToString()].GetComponent<LEDControls>().Move(z, x, 0.0,0.93f);
            speakers[counter.ToString()].GetComponent<LEDControls>().centerLED.GetComponent<UnityEngine.Animations.LookAtConstraint>().AddSource(c);
            speakers[counter.ToString()].GetComponent<LEDControls>().centerLED.SetActive(false);
            counter++;
            

        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
