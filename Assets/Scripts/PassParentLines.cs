using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassParentLines : MonoBehaviour
{   
    public string[] lines = {};
    public string[] yourLines = {};
    public string[] lines2 = {};
    public string[] yourLines2 = {};
    public bool exhausted;

    // Start is called before the first frame update
    void Start()
    {
        lines[0] = "<i>The woman is sitting, seemingly calm.</i>";                 // Narrative description
        yourLines[0] = "Hey, uh... excuse me.";
        lines[1] = "Mhm?";
        yourLines[1] = "I'm sorry, do you know what's going on?";
        lines[2] = "It's probably a mistake. This situation. They probably forgot about us, we're at the back of a train.";
        yourLines[2] = "Yeah, but... Do you know where we are?";
        lines[3] = "Probably a gas leak.";
        yourLines[3] = "I'm sorry...?";
        lines[4] = "Gas leak or something, just messing with our heads. Can't remember.";
        yourLines[4] = "That doesn't sound right... But thanks.";
        
        lines2[0] = "<i>She is still trying her best to stay calm.</i>";           // Narrative description
        yourLines2[0] = "Hey, sorry. We're trying to figure out why we're here. Could you check your phone, in case you got like pictures or something?";
        lines2[1] = "Pictures?";
        yourLines2[1] = "Yeah. Like pictures of anyone here.";
        lines2[2] = "This is kind of weird, but okay..";
        yourLines2[2] = "";
        lines2[3] = "<i>You spend a while looking through her phone.</i>";         // Narrative description
        yourLines2[3] = "";
        lines2[4] = "My kids... Have you seen any children?";
        yourLines2[4] = "Sorry, I haven't.";
        lines2[5] = "How about this guy?";
        yourLines2[5] = "";
        lines2[6] = "<i>She shows you a picture of a rough looking guy.</i>";      // Narrative description 
        yourLines2[6] = "I'll go see, thanks.";
        lines2[7] = "...";
        yourLines2[7] = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
