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
        lines[0] = "<i>It just works.</i>";
        yourLines[0] = "";
        lines[0] = "Do <b>not</b> press that button !";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
