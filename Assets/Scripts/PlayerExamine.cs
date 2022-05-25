using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExamine : MonoBehaviour
{
    public bool examine;
    EnterTraincar traincar;
    private void OnTriggerStay2D(Collider2D col) {
        if (col.tag == "Person" && examine == true) {
            // Start Dialogue
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
