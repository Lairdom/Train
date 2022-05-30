using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExamine : MonoBehaviour
{
    public bool examine;
    EnterTraincar traincar;
    Talk dialog;
    GameObject playerDialog;
    bool onTrigger;
    Collider2D col;
    public bool examining;
    public bool screenFade;

    private void OnTriggerEnter2D(Collider2D collider) {
        onTrigger = true;
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
        dialog = GameObject.Find("DialogueBox").GetComponent<Talk>();
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
                dialog.StartDialogue(col.name);
            }
            else if (col.tag == "Interactable") {
                // Examine Object
                if (col.gameObject.name == "TrainExit") {
                    traincar.goNext = true;
                }
                else if (col.gameObject.name == "TrainEntrance") {
                    traincar.goPrev = true;
                }
            }
        }
        else if (examine == true && onTrigger == false) {
            examine = false;
        }

        // Turn textbox off
        if (examining == false) {
            dialog.gameObject.SetActive(false);
            playerDialog.SetActive(false);
        }
    }
}
