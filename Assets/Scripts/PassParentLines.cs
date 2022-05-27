using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassParentLines : MonoBehaviour
{   
    public string[] lines = {};
    public string[] lines2 = {};

    // Start is called before the first frame update
    void Start()
    {
        lines[0] = "Mhm?";
        lines[1] = "It's probably a mistake. This situation. They probably forgot about us, we're at the back of a train.";
        lines[2] = "Probably a gas leak.";
        lines[3] = "Gas leak or something, just messing with our heads. Can't remember.";

        lines2[0] = "Pictures?";
        lines2[1] = "This is kind of wierd, but okay..";
        lines2[2] = "My kids... Have you seen any children?";
        lines2[3] = "How about this guy?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
