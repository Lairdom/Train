using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Talk : MonoBehaviour
{
    int ind;

    [SerializeField] float textSpeed;
    [SerializeField] string[] lines = {};

    [SerializeField] TextMeshProUGUI textComponent;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = "";

        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && textComponent.text == lines[ind])
            NextLine();

        if(Input.GetButtonDown("Fire2") && textComponent.text != lines[ind])
        {
            StopCoroutine("TypeLine");

            textComponent.text = lines[ind];
        }
    }

    private void NextLine()
    {
        if(ind < lines.Length - 1)
        {
            ind++;
            
            textComponent.text = "";

            StartCoroutine("TypeLine");
        }
    }

    private void StartDialogue()
    {
        ind = 0;

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
