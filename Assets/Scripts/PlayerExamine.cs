using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExamine : MonoBehaviour
{
    public bool examine;
    EnterTraincar traincar;
    Talk dialog;
    private void OnTriggerStay2D(Collider2D col) {
        if (col.tag == "Person" && examine == true) {
            // Start Dialogue
            if (dialog.started == true)
                dialog.NextLine();
            else 
                dialog.StartDialogue(col.name);
            
            Debug.Log("Dialogue");
        }
        else if (col.tag == "Interactable" && examine == true) {
            // Examine Object
            if (col.gameObject.name == "TrainExit") {
                traincar.goNext = true;
            }
            else if (col.gameObject.name == "TrainEntrance") {
                traincar.goPrev = true;
            }
            
        }
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        examine = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        examine = false;
        traincar = GameObject.Find("Train").GetComponent<EnterTraincar>();
        dialog = GameObject.Find("DialogueBox").GetComponent<Talk>();
    }

    // Update is called once per frame
    void Update()
    {
        if (examine == true) {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else 
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
