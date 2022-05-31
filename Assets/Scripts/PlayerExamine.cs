using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExamine : MonoBehaviour
{
    public bool examine;
    EnterTraincar traincar;
    Talk talk;
    GameObject playerDialog, dialog;
    bool onTrigger;
    Collider2D col;
    public bool examining;
    public bool screenFade;

    private void OnTriggerEnter2D(Collider2D collider) {
        onTrigger = true;
        Debug.Log(collider);
        col = collider;
    }
    private void OnTriggerExit2D(Collider2D collider) {
        onTrigger = false;
        col = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        examine = false;
        traincar = GameObject.Find("Train").GetComponent<EnterTraincar>();
        talk = GameObject.Find("GameManager").GetComponent<Talk>();
        dialog = GameObject.Find("DialogueBox");
        playerDialog = GameObject.Find("PlayerDialogueBox");
        screenFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (examine == true && onTrigger == true) {
            examine = false;
            if (col.tag == "Person") {
                // Start Dialogue
                examining = true;
                dialog.gameObject.SetActive(true);
                playerDialog.SetActive(true);
                talk.StartDialogue(col.name);
            }
            else if (col.tag == "Interactable") {
                // Examine Object
                if (col.gameObject.name == "TrainExit") {
                    traincar.goNext = true;
                }
                else if (col.gameObject.name == "TrainEntrance") {
                    traincar.goPrev = true;
                }
                else if (col.gameObject.name == "Sign(Clone)") {
                    Debug.Log("Sign");
                    examining = true;
                    dialog.gameObject.SetActive(true);
                    // playerDialog.SetActive(true);
                    talk.StartDialogue(col.name);
                }
            }
        }
        else if (examine == true && onTrigger == false) {
            if (GameObject.Find("GameManager").GetComponent<Talk>().startEnd == true) {
                examining = true;
                talk.StartDialogue(null);
            }
            examine = false;
        }

        // Turn textbox off
        if (examining == false) {
            dialog.gameObject.SetActive(false);
            playerDialog.SetActive(false);
        }
    }
}
