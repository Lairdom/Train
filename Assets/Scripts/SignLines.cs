using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignLines : MonoBehaviour
{
    public string[] lines = {};
    public string[] yourLines = {};

    // Start is called before the first frame update
    void Start()
    {
        lines[0] = "<i>It just works.</i>"; // Joona
        //yourLines[0] = "";
        lines[1] = "Do <b>not</b> press that button !"; // Hrax Keen
        lines[2] = "Help me... \n...\n...get out"; // markun contribuutio
        lines[3] = "Come find me from the restaurant car. I'll buy you a beer!"; //Ari
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
