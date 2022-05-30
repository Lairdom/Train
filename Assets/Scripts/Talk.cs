using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Talk : MonoBehaviour
{
    int ind, pInd;

    [SerializeField] float textSpeed;
    [SerializeField] string[] lines = {};
    [SerializeField] string[] yourLines = {};
    [SerializeField] TextMeshProUGUI textComponent, textComponent2;
    public bool parentAdvance, addictAdvance, hustlerAdvance, priestAdvance, programmerAdvance;
    public bool started, end;
    public static Talk instance;
    string nimi;
    EnterTraincar train;
    public bool startEnd;
    public GameObject target;
    
    void Awake(){
        instance = this;
    }
    void Start()
    {
        textComponent.text = "";
        textComponent2.text = "";
        parentAdvance = false; addictAdvance = false; hustlerAdvance = false;
        priestAdvance = false; programmerAdvance = false;
        train = GameObject.Find("Train").GetComponent<EnterTraincar>();
        end = false; startEnd = false;
    }

    void Update()
    {
        
    }

    public void NextLine()
    {
        if (startEnd == true) {
            if (ind == 0 || ind == 1 || ind == 3 || ind == 5 || ind == 8 || ind == 10 || ind == 12 || ind == 14 || ind == 16 || ind == 18) 
                target = GameObject.Find("PassengerHustler(Clone)");
            else if (ind == 2 || ind == 4 || ind == 6) 
                target = GameObject.Find("PassengerPriest(Clone)");
            else if (ind == 7 || ind == 9 || ind == 11 || ind == 13) 
                target = GameObject.Find("PassengerProg...(Clone)");
            else if (ind == 15) 
                target = GameObject.Find("PassengerParent(Clone)");
            else if (ind == 17) 
                target = GameObject.Find("PassengerAddict(Clone)");
            else
                target = GameObject.Find("Player");
        }
        if (textComponent.text != lines[ind] || textComponent2.text != yourLines[pInd]) {
                StopCoroutine("TypeLine");
                textComponent.text = lines[ind];
                textComponent2.text = yourLines[pInd];
            }
        else if(ind < lines.Length - 1 || pInd < yourLines.Length -1)
        {
            ind++;
            pInd++;
            textComponent.text = "";
            textComponent2.text = "";
            StartCoroutine("TypeLine");
        }
        else if (ind >= lines.Length -1) {
            if (nimi == "PassengerProg...(Clone)" && programmerAdvance == false) {
                parentAdvance = true;
            }
            else if (nimi == "PassengerParent(Clone)" && parentAdvance == true) {
                hustlerAdvance = true;
            }
            else if (nimi == "PassengerHustler(Clone)" && hustlerAdvance == true) {
                programmerAdvance = true;
            }
            else if (nimi == "PassengerProg...(Clone)" && programmerAdvance == true) {
                end = true;
            }
            GameObject.Find("Examine").GetComponent<PlayerExamine>().examining = false;
            started = false;
            startEnd = false;
        }
    }

    public void StartDialogue(string name)
    {
        // If talking to Parent
        if (name == "PassengerParent(Clone)") {
            nimi = name;

            // Check if we have advanced parent dialogue
            if (parentAdvance == false) {
                lines = GameObject.Find("PassengerParent(Clone)").GetComponent<PassParentLines>().lines;
                yourLines = GameObject.Find("PassengerParent(Clone)").GetComponent<PassParentLines>().yourLines;
            }
            else {
                lines = GameObject.Find("PassengerParent(Clone)").GetComponent<PassParentLines>().lines2;
                yourLines = GameObject.Find("PassengerParent(Clone)").GetComponent<PassParentLines>().yourLines2;
            }

            // Start of dialogue
            if (started == false) {
                started = true;
                ind = 0;
                pInd = 0;
                textComponent.text = "";
                textComponent2.text = "";
                StartCoroutine("TypeLine");
            }
            else if (started == true) {
                NextLine();
            }
        }

        // If talking to Hustler
        else if (name == "PassengerHustler(Clone)") {
            nimi = name;

            // Check if we have advanced hustler dialogue
            if (hustlerAdvance == false) {
                lines = GameObject.Find("PassengerHustler(Clone)").GetComponent<PassHustlerLines>().lines;
                yourLines = GameObject.Find("PassengerHustler(Clone)").GetComponent<PassHustlerLines>().yourLines;
            }
            else {
                lines = GameObject.Find("PassengerHustler(Clone)").GetComponent<PassHustlerLines>().lines2;
                yourLines = GameObject.Find("PassengerHustler(Clone)").GetComponent<PassHustlerLines>().yourLines2;
            }

            // Start of dialogue
            if (started == false) {
                started = true;
                ind = 0;
                pInd = 0;
                textComponent.text = "";
                textComponent2.text = "";
                StartCoroutine("TypeLine");
            }
            else if (started == true) {
                NextLine();
            }
        }

        // If talking to Addict
        else if (name == "PassengerAddict(Clone)") {
            nimi = name;

            // Check if we have advanced addict dialogue
            if (addictAdvance == false) {
                lines = GameObject.Find("PassengerAddict(Clone)").GetComponent<PassAddictLines>().lines;
                yourLines = GameObject.Find("PassengerAddict(Clone)").GetComponent<PassAddictLines>().yourLines;
            }
            else {
                lines = GameObject.Find("PassengerAddict(Clone)").GetComponent<PassAddictLines>().lines2;
                yourLines = GameObject.Find("PassengerAddict(Clone)").GetComponent<PassAddictLines>().yourLines2;
            }

            // Start of dialogue
            if (started == false) {
                started = true;
                ind = 0;
                pInd = 0;
                textComponent.text = "";
                textComponent2.text = "";
                StartCoroutine("TypeLine");
            }
            else if (started == true) {
                NextLine();
            }
        }

        // If talking to Priest
        else if (name == "PassengerPriest(Clone)") {
            nimi = name;

            // Check if we have advanced priest dialogue
            if (priestAdvance == false) {
                lines = GameObject.Find("PassengerPriest(Clone)").GetComponent<PassPriestLines>().lines;
                yourLines = GameObject.Find("PassengerPriest(Clone)").GetComponent<PassPriestLines>().yourLines;
            }
            else {
                lines = GameObject.Find("PassengerPriest(Clone)").GetComponent<PassPriestLines>().lines2;
                yourLines = GameObject.Find("PassengerPriest(Clone)").GetComponent<PassPriestLines>().yourLines2;
            }

            // Start of dialogue
            if (started == false) {
                started = true;
                ind = 0;
                pInd = 0;
                textComponent.text = "";
                textComponent2.text = "";
                StartCoroutine("TypeLine");
            }
            else if (started == true) {
                NextLine();
            }
        }

        // If talking to Programmer
        else if (name == "PassengerProg...(Clone)") {
            nimi = name;

            // Check if we have advanced programmer dialogue
            if (programmerAdvance == false) {
                lines = GameObject.Find("PassengerProg...(Clone)").GetComponent<PassProgrammerLines>().lines;
                yourLines = GameObject.Find("PassengerProg...(Clone)").GetComponent<PassProgrammerLines>().yourLines;
            }
            else {
                lines = GameObject.Find("PassengerProg...(Clone)").GetComponent<PassProgrammerLines>().lines2;
                yourLines = GameObject.Find("PassengerProg...(Clone)").GetComponent<PassProgrammerLines>().yourLines2;
            }

            // Start of dialogue
            if (started == false) {
                started = true;
                ind = 0;
                pInd = 0;
                textComponent.text = "";
                textComponent2.text = "";
                StartCoroutine("TypeLine");
            }
            else if (started == true) {
                NextLine();
            }
        }
        else if (name == null && startEnd == true) {
            if (started == false) {
                target = GameObject.Find("PassengerHustler(Clone)");
                started = true;
                lines = GetComponent<EndSceneLines>().lines;
                yourLines = GetComponent<EndSceneLines>().yourLines;
                ind = 0;
                pInd = 0;
                textComponent.text = "";
                textComponent2.text = "";
                StartCoroutine("TypeLine");
            }
            else if (started == true) {
                NextLine();
            }
        }
    }

    IEnumerator TypeLine()
    {
        // Debug.Log(lines[ind]);
        foreach(char c in lines[ind])
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
