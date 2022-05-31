using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassAddictLines : MonoBehaviour
{
    public string[] lines = {};
    public string[] yourLines = {};
    public string[] lines2 = {};
    public string[] yourLines2 = {};
    public bool exhausted;
    // Start is called before the first frame update
    void Start()
    {
        lines[0] = "<i> The man is smoking. Based on the smell it ain't cigarettes. </i>";           // Narrative description
        yourLines[0] = "Excuse me.";
        lines[1] = "Hey, whatchu need?";
        yourLines[1] = "Do you know what's going on?";
        lines[2] = "Yeah, man. Relax, you should sit down. It'll be okay. It's gonna pass, aight?";
        yourLines[2] = "I'm sorry?";
        lines[3] = "Look, we're all just tripping. Calm down, man. Take it slow... Sit down, take deep breaths, you'll get through this. It'll be okay.";
        yourLines[3] = "I'm not... tripping.";
        lines[4] = "You look real jumpy.";
        yourLines[4] = "It's okay, thanks...";
        lines[5] = "Hey! One more thing.";
        yourLines[5] = "Yes?";
        lines[6] = "Got a light?";
        yourLines[6] = "Don't you have a lit cigarette already?";
        lines[7] = "Oh, you're right. Thanks man.";
        yourLines[7] = "...";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
