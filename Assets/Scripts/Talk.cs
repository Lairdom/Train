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
    bool advance;
    public bool started;


    void Start()
    {
        textComponent.text = "";
        textComponent2.text = "";
        advance = false;
    }

    void Update()
    {

    }

    public void NextLine()
    {
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
            GameObject.Find("Examine").GetComponent<PlayerExamine>().examining = false;
            started = false;
        }
    }

    public void StartDialogue(string name)
    {
        // If talking to Parent
        if (name == "PassengerParent(Clone)") {

            // Check if we have advanced parent dialogue
            advance = GameObject.Find("PassengerParent(Clone)").GetComponent<PassParentLines>().advance;
            if (advance == false) {
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
            
            // Check if we have advanced hustler dialogue
            advance = GameObject.Find("PassengerHustler(Clone)").GetComponent<PassHustlerLines>().advance;
            if (advance == false) {
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
            
            // Check if we have advanced hustler dialogue
            advance = GameObject.Find("PassengerAddict(Clone)").GetComponent<PassAddictLines>().advance;
            if (advance == false) {
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
