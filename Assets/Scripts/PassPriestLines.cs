using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPriestLines : MonoBehaviour
{
    public string[] lines = {};
    public string[] yourLines = {};
    public string[] lines2 = {};
    public string[] yourLines2 = {};
    public bool exhausted;
    // Start is called before the first frame update
    void Start()
    {
        lines[0] = "<i> The Priest is waving his hand to sky near the back of the cart. </i>";       // Narrative description
        yourLines[0] = "Excuse me.";
        lines[1] = "Please, leave me be...";
        yourLines[1] = "I'm sorry, I was just-";
        lines[2] = "You cannot shake me.";
        yourLines[2] = "...What?";
        lines[3] = "I've held faith. I have. I've prayed for forgiveness... I'm sincere... You can't shake me.";
        yourLines[3] = "I'm sorry, I was just gonna ask if you know why we're here...";
        lines[4] = "You know why... You're just here to test me.";
        yourLines[4] = "Oookay...";
        lines[5] = "...";
        yourLines[5] = "My man, I don't know what is going on.";
        lines[6] = "...This is a test. We're being tested.";
        yourLines[6] = "It's just a train.";
        lines[7] = "The doors are locked, it isn't stopping. Destination unknown, our pasts wiped clean... But you know what you've done. You know why you're here. I do too.";
        yourLines[7] = "Right. I'll just... Leave you to it.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
