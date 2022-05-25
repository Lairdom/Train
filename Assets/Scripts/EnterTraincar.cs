using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTraincar : MonoBehaviour
{
    public string traincar;
    public bool goNext, goPrev;
    [SerializeField] GameObject addict, hustler, parent, programmer, priest;
    GameObject player, npc1, npc2, npc3;

    void MovePlayer() {
        if (player.transform.position.x > 0) {
            // Move to Entrance
            player.transform.position = new Vector2(-9.4f,player.transform.position.y);
        }
        else {
            // Move to Exit
            player.transform.position = new Vector2(9.5f,player.transform.position.y);
        }

    }
    IEnumerator ChangeTraincar() {
        // Fadeout
        yield return new WaitForSeconds(0.2f);
        MovePlayer();                                                                                               // Move Player to correct side of the train
        Destroy(npc1); Destroy(npc2); Destroy(npc3);                                                                // Destroy all NPCs
        if (traincar == "Car1") {
            // Instantiate Traincar 1 NPCs & Objects
        }
        else if (traincar == "Car2") {
            npc1 = Instantiate(parent,new Vector2(-2.11f,-0.95f),transform.rotation,transform.parent);              // Instantiate Traincar 2 NPCs & Objects
        }
        else if (traincar == "Car3") {
            // Instantiate Traincar 3 NPCs & Objects
        }
        else if (traincar == "Car4") {
            // Instantiate Traincar 4 NPCs & Objects
        }
        // Fadein
    }
    void Start()
    {
        player = GameObject.Find("Player");
        goNext = false;
        goPrev = false;
    }

    void Update()
    {
        if (traincar == "Car1") {
            if (goNext == true) {
                Debug.Log("Entering Traincar 2");
                traincar = "Car2";
                StartCoroutine(ChangeTraincar());
                goNext = false;
            }
            else if (goPrev == true) {
                Debug.Log("Entering Traincar 4");
                traincar = "Car4";
                StartCoroutine(ChangeTraincar());
                goPrev = false;
            }
        }
        else if (traincar == "Car2") {
            if (goNext == true) {
                Debug.Log("Entering Traincar 3");
                traincar = "Car3";
                StartCoroutine(ChangeTraincar());
                goNext = false;
            }
            else if (goPrev == true) {
                Debug.Log("Entering Traincar 1");
                traincar = "Car1";
                StartCoroutine(ChangeTraincar());
                goPrev = false;
            }
        }
        else if (traincar == "Car3") {
            if (goNext == true) {
                Debug.Log("Entering Traincar 4");
                traincar = "Car4";
                StartCoroutine(ChangeTraincar());
                goNext = false;
            }
            else if (goPrev == true) {
                Debug.Log("Entering Traincar 2");
                traincar = "Car2";
                StartCoroutine(ChangeTraincar());
                goPrev = false;
            }
        }
        else if (traincar == "Car4") {
            if (goNext == true) {
                Debug.Log("Entering Traincar 1");
                traincar = "Car1";
                StartCoroutine(ChangeTraincar());
                goNext = false;
            }
            else if (goPrev == true) {
                Debug.Log("Entering Traincar 3");
                traincar = "Car3";
                StartCoroutine(ChangeTraincar());
                goPrev = false;
            }
        }
    }
}
