using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TalkCopy : MonoBehaviour
{
    int ind;
    [SerializeField] float textSpeed;
    [SerializeField] string[] lines = {};
    [SerializeField] TextMeshProUGUI textComponent;
    public bool started;

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

            textComponent.text = lines[ind];
        }
    }

    public void NextLine()
    {
        if(ind < lines.Length - 1)
        {
            ind++;
            textComponent.text = "";
            StartCoroutine("TypeLine");
        }
    }

    public void StartDialogue(string name)
    {
        if (name == "PassengerParent(Clone)") {
            lines = GameObject.Find("PassengerParent(Clone)").GetComponent<PassParentLines>().lines;
        }
        started = true;
        ind = 0;
        textComponent.text = "";
        StartCoroutine("TypeLine");
        
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
