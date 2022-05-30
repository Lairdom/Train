using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Talk2 : MonoBehaviour
{
    int ind;

    string line;

    [SerializeField] float textSpeed;
    [SerializeField] string[] lines = {};

    [SerializeField] TextAsset[] txt; 

    [SerializeField] TextMeshProUGUI textComponent;

    public bool started;

    Color pl = Color.white;
    Color ad = Color.cyan;
    Color hs = Color.blue;
    Color pg = Color.green;    
    Color pr = Color.red;
    Color pt = Color.black;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = "";
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2") && textComponent.text != lines[ind])
        {
            StopCoroutine("TypeLine");

            textComponent.text = line;
        }
    }

    private void FeedText()
    {
        Debug.Log("feed");

        var text = lines[ind];

        if(text.Length == 1)
        {
            ind++;

            text = lines[ind];
        }

    var t = text.Split(':');

    if(t[0].Length > 2)
        line = t[0];
    else    
        if(t[0].Length == 2)
        {    
            switch(t[0])
            {
                case "PL":
                    Debug.Log(t[1]);

                    ChangeColor(pl);

                    break;

                case "AD":
                    Debug.Log(t[1]);

                    ChangeColor(ad);

                    break;

                case "HS":
                    Debug.Log(t[1]);

                    ChangeColor(hs);

                    break;

                case "PG":
                    Debug.Log(t[1]);

                    ChangeColor(pg);

                    break;

                case "PR":
                    Debug.Log(t[1]);

                    ChangeColor(pr);

                    break;

                case "PT":
                    Debug.Log(t[1]);

                    ChangeColor(pt);

                    break;
            }

            line = t[1];
        }
    }

    public void NextLine()
    {
        if(ind < lines.Length - 1)
        {
            ind++;
            
            textComponent.text = "";

            FeedText();

            StartCoroutine("TypeLine");
        }
    }

    public void StartDialogue(string name)
    {
        if (name == "PassengerParent(Clone)") {
            Debug.Log("Parent Talking");
        }

        name = "PassengerAddict(Clone)";
        // name = "PassengerHustler(Clone)";

        switch(name)
        {
            case "PassengerAddict(Clone)":
                lines = txt[0].text.Split('\n');
                
                break;

            case "PassengerHustler(Clone)":
                lines = txt[1].text.Split('\n');
                
                break;
            case "PassengerParent(Clone)":
                
                
                break;
        }

        started = true;
        ind = 0;
        textComponent.text = "";
        
        FeedText();

        StartCoroutine("TypeLine");
    }

    IEnumerator TypeLine()
    {
        foreach(char c in line)
        {
            textComponent.text += c;
            
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void ChangeColor(Color c)
    {
        var t = GameObject.Find("Text (TMP)");

        t.GetComponent<TextMeshProUGUI>().color = c;
    }
}
