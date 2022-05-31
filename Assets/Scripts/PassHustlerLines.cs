using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassHustlerLines : MonoBehaviour
{
    public string[] lines = {};
    public string[] yourLines = {};
    public string[] lines2 = {};
    public string[] yourLines2 = {};
    public bool exhausted;

    public void KickSound() {
        GetComponent<AudioSource>().Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        lines[0] = "<i>The man is banging on the cart's front door and screaming. </i>";            // Narrative description
        yourLines[0] = "";
        lines[1] = "GET THE FUCK AWAY FROM ME!";
        yourLines[1] = "Jesus! Sorry!";

        lines2[0] = "STAY BACK! Or I swear to god!";
        yourLines2[0] = "Whoa, hey... I just wanna talk.";
        lines2[1] = "The fuck you want?";
        yourLines2[1] = "Just figure out what's going on here. We're uh.. Connected, you know? People here.";
        lines2[2] = "Well no shit.";
        yourLines2[2] = "Wait, what? You know?";
        lines2[3] = "We've all pissed off someone. It's probably a maintenance rail, just goes in circles. Probably the fucking mafia.";
        yourLines2[3] = "I'm sorry, the mafia? What?";
        lines2[4] = "Yeah, drugged us, abducted us. Now they're just fucking with us. By the time the train stops, we're gonna be fucked. They're gonna come in here with guns and bats.";
        yourLines2[4] = "Okay... So... What do we do?";
        lines2[5] = "What?";
        yourLines2[5] = "Well... fucking banging the door isn't doing anything, the fuck we do?";
        lines2[6] = "<i>The man is clearly on the edge of snapping. </i>";                          // Narrative description
        yourLines2[6] = "I just wanna live and get what the fuck is going on here...";
        lines2[7] = "Okay. Alright. I need to think, gimme space.";
        yourLines2[7] = "Okay, alright.";
        lines2[8] = "Fuck off.";
        yourLines2[8] = "Yeah. See you...";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
