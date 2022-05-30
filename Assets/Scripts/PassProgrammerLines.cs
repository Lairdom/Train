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
        lines[4] = "So, if it's possible for us to create a convincing simulation of reality, ";
        yourLines[4] = "";
        lines[5] = "then it's infinitely possible that someone already did it before us, and we're much more likely to be in a simulation of a simulation, rather than the original universe.";
        yourLines[5] = "What the fuck?";
        lines[6] = "Alright, so essentially. We're stuck in a debugging area. How we got here, I'm not sure. But it's big. Look, did you check your phone?";
        yourLines[6] = "Don't have it on me...";
        lines[7] = "Okay, well; it's not running out of power. It's stuck. But we got all the pictures and files from before, look.";
        yourLines[7] = "Okay...?";
        lines[8] = "It's taken us out the system, and put us to isolation. There's some connection between us, you know?";
        yourLines[8] = "No...?";
        lines[9] = "I got pictures of somebody here. I saw her on the train. I need you to check up with her, see what she got on her phone.";
        yourLines[9] = "Why don't you ask yourself?";
        lines[10] = "I uh... I'd feel awkward doing that.";
        yourLines[10] = "Okay... Fine.";

        lines2[0] = "The programmer is still weirdly excited.";       // Narrative description
        yourLines2[0] = "I talked to her.";
        lines2[1] = "She remember me?";
        yourLines2[1] = "Uh... What?";
        lines2[2] = "Did she remember me?";
        yourLines2[2] = "She didn't... mention.. You didn't ask me to ask either?";
        lines2[3] = "Okay, fine.";
        yourLines2[3] = "I can go and ask if-";
        lines2[4] = "No, forget about it.\nThe phone?";
        yourLines2[4] = "Yeah, it had some pictures... Wait, you remember her?";
        lines2[5] = "No. Any pictures of me?";
        yourLines2[5] = "Someone else.";
        lines2[6] = "Okay. Yeah, that's it. We're all somehow tied to each other.";
        yourLines2[6] = "Look, I don't remember you... Don't remember anyone-";
        lines2[7] = "What's your name?";
        yourLines2[7] = "Uh.. What?";
        lines2[8] = "What's your name?";
        yourLines2[8] = "...";
        lines2[9] = "You're not sure, right? You don't know what your fucking name is, right? How the fuck can you forget your own name?";
        yourLines2[9] = "Look.. It could be drugs.. Or gas..";
        lines2[10] = "Are you for fucking real? Drugs? Gas? Dude.. It's a glitch, and we've been put away. ";
        yourLines2[10] = "";
        lines2[11] = "We're not getting out, we're all gonna spend the fucking eternity here. This is it, till end of fucking time.";
        yourLines2[11] = "What the fuck is wrong with you..?";
        lines2[12] = "With me? What the fuck is wrong with me? I'm surrounded by fucking idiots, by fucking imbeciles. What the fuck is wrong with you?";
        yourLines2[12] = "";
        lines2[13] = "You can't tell your name, much less your address or year of birth, can you tell what year it is?";
        yourLines2[13] = "";
        lines2[14] = "Can you tell what day of the week? And you're saying what's wrong with me? Fucking gas?";
        yourLines2[14] = "What the fuck..";
        lines2[15] = "I know... We're done. This is it. We've been swept away, and if we're lucky, they'll delete the cache sooner rather than later.";
        yourLines2[15] = "You're fucking insane.";
        lines2[16] = "I'm the only sane one here.";
        yourLines2[16] = "What the fuck...";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
