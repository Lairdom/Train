using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassProgrammerLines : MonoBehaviour
{
    public string[] lines = {};
    public string[] yourLines = {};
    public string[] lines2 = {};
    public string[] yourLines2 = {};
    public bool advance, exhausted;
    // Start is called before the first frame update
    void Start()
    {
        lines[0] = "The man is staring out the window excitedly.";       // Narrative description
        yourLines[0] = "";
        lines[1] = "Hey!";
        yourLines[1] = "Hey, sorry, do you-";
        lines[2] = "Isn't this crazy?!";
        yourLines[2] = "...Well-";
        lines[3] = "Dude, like, you know simulation theory?";
        yourLines[3] = "Wait, I-";
        lines[4] = "So, if it's possible for us to create a convincing simulation of reality, then it's infinitely possible that someone already did it before us, and we're much more likely to be in a simulation of a simulation, rather than the original universe.";
        yourLines[4] = "What the fuck?";
        lines[5] = "Alright, so essentially. We're stuck in a debugging area. How we got here, I'm not sure. But it's big. Look, did you check your phone?";
        yourLines[5] = "Don't have it on me...";
        lines[6] = "Okay, well; it's not running out of power. It's stuck. But we got all the pictures and files from before, look.";
        yourLines[6] = "Okay...?";
        lines[7] = "It's taken us out the system, and put us to isolation. There's some connection between us, you know?";
        yourLines[7] = "No...?";
        lines[8] = "I got pictures of somebody here. I saw her on the train. I need you to check up with her, see what she got on her phone.";
        yourLines[8] = "Why don't you ask yourself?";
        lines[9] = "I uh... I'd feel awkward doing that.";
        yourLines[9] = "Okay... Fine.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
