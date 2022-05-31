using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Talk : MonoBehaviour
{
    int ind, pInd;

    [SerializeField] float textSpeed;
    [SerializeField] string[] lines = {};
    [SerializeField] string[] yourLines = {};
    [SerializeField] TextMeshProUGUI textComponent, textComponent2;
    public bool parentAdvance, addictAdvance, hustlerAdvance, priestAdvance, programmerAdvance;
    public bool parentExhausted, addictExhausted, hustlerExhausted, priestExhausted, programmerExhausted;
    public bool started, end;
    public static Talk instance;
    string nimi;
    EnterTraincar train;
    public bool startEnd;
    public GameObject target;
    bool doorsOpen;
    float timer;
    
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
        target = GameObject.Find("Player");
        doorsOpen = false;
        parentExhausted = false; addictExhausted = false; hustlerExhausted = false;
        priestExhausted = false; programmerExhausted = false;
    }

    void Update()
    {
        if (doorsOpen == true) {
            GameObject.Find("DoorL").transform.localPosition = Vector2.Lerp(new Vector2(-0.62f,-0.458f), new Vector2(-1.81f,-0.458f),timer);
            GameObject.Find("DoorR").transform.localPosition = Vector2.Lerp(new Vector2(0.59f,-0.458f), new Vector2(1.65f,-0.458f),timer);
            timer += Time.deltaTime;
        }
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
            if (nimi == "PassengerAddict(Clone)" && addictAdvance == false) {
                addictExhausted = true;
            }
            else if (nimi == "PassengerProg...(Clone)" && programmerAdvance == false) {
                programmerExhausted = true;
                parentAdvance = true;
                parentExhausted = false;
            }
            else if (nimi == "PassengerProg...(Clone)" && programmerAdvance == true) {
                programmerExhausted = true;
                end = true;
            }
            else if (nimi == "PassengerParent(Clone)" && parentAdvance == false) {
                parentExhausted = true;
            }
            else if (nimi == "PassengerParent(Clone)" && parentAdvance == true) {
                parentExhausted = true;
                hustlerAdvance = true;
                hustlerExhausted = false;
            }
            else if (nimi == "PassengerHustler(Clone)" && hustlerAdvance == false) {
                hustlerExhausted = true;
            }
            else if (nimi == "PassengerHustler(Clone)" && hustlerAdvance == true) {
                hustlerExhausted = true;
                programmerAdvance = true;
                programmerExhausted = false;
            }
            else if (nimi == "PassengerPriest(Clone)" && priestAdvance == false) {
                priestExhausted = true;
            } else {
                Debug.Log($"{ind >= lines.Length -1} Here {ind} - {lines.Length -1}");
                SignEnd();
                return;
            }
            if (startEnd == true) {
                StartCoroutine(Ending());
                startEnd = false;
            }
            SignEnd();
            return;
            //GameObject.Find("Examine").GetComponent<PlayerExamine>().examining = false;
            //started = false;
            
        }
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

            // Check if we have exhausted parent lines
            if (parentExhausted == true) {
                if (parentAdvance == true) {
                    ind = 7;
                    pInd = 7;
                    // textComponent.text = "";
                    // textComponent2.text = "";
                }
                else {
                    ind = 4;
                    pInd = 4;
                    // textComponent.text = "";
                    // textComponent2.text = "";
                }
                started = true;
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

            // Check if we have exhausted hustler lines
            if (hustlerExhausted == true) {
                if (hustlerAdvance == true) {
                    ind = 8;
                    pInd = 8;
                }
                else {
                    ind = 1;
                    pInd = 1;
                }
                started = true;
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

            // Check if we have exhausted addict lines
            if (addictExhausted == true) {
                ind = 7;
                pInd = 7;
                started = true;
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

            // Check if we have exhausted priest lines
            if (priestExhausted == true) {
                ind = 7;
                pInd = 7;
                started = true;
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

            // Check if we have exhausted programmer lines
            if (programmerExhausted == true) {
                if (programmerAdvance == true) {
                    ind = 16;
                    pInd = 16;
                }
                else {
                    ind = 11;
                    pInd = 11;
                }
                started = true;
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
        else if (name == "Sign(Clone)") {
            nimi = name;
            lines = GameObject.Find("Sign(Clone)").GetComponent<SignLines>().lines;
            yourLines = GameObject.Find("Sign(Clone)").GetComponent<SignLines>().yourLines;
            if (started == false) {
                started = true;
                ind = UnityEngine.Random.Range(0,4);
                pInd = 0;
                textComponent.text = "";
                textComponent2.text = "";
                StartCoroutine("TypeLine");
            }
            else if (started == true) {
                SignEnd();
            }

        }

        else if (name == "Locked") {
            nimi = name;
            // string[] locked = {"Locked"};
            lines[0] = "Locked";
            yourLines[0] = "";
            if (started == false) {
                started = true;
                ind = 0;
                pInd = 0;
                textComponent.text = "";
                textComponent2.text = "";
                StartCoroutine("TypeLine");
            }
            else if (started == true) {
                SignEnd();
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
        string apumuuttuja = "";
        // Debug.Log(lines[ind]);
        foreach(char c in lines[ind])
        {
            if (c.ToString() == "<"){
                apumuuttuja = c.ToString();
                continue;
            }
            if(apumuuttuja.Length > 0){
                apumuuttuja += c.ToString();

                if(c.ToString() == ">"){
                    textComponent.text += apumuuttuja;
                    apumuuttuja = "";
                }
                continue;
            }
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator Ending() {
        BGManager.instance.stopTrain();
        yield return new WaitForSeconds(1);
        GameObject.Find("Player").GetComponentInChildren<PlayerExamine>().examining = true;
        yield return new WaitForSeconds(4);
        target = GameObject.Find("Doors");
        startEnd = true;
        doorsOpen = true;
        yield return new WaitForSeconds(1);
        Fade.RequestFade = true;
        // To Be Continued
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void SignEnd(){
        if(textComponent.text == lines[ind]){
            GameObject.Find("Examine").GetComponent<PlayerExamine>().examining = false;
            started = false;
            textComponent.text = "";
            textComponent2.text = "";
        }
        else if (textComponent.text != lines[ind] || textComponent2.text != yourLines[pInd]) {
            StopCoroutine("TypeLine");
            textComponent.text = lines[ind];
            textComponent2.text = yourLines[pInd];
        }
    }

    void StartingScene(){

    }
}
