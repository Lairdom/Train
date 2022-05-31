using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterTraincar : MonoBehaviour
{
    public string traincar;
    public bool goNext = false, goPrev = false;
    [SerializeField] GameObject addict, hustler, parent, programmer, priest, sign;
    GameObject player, npc1, npc2, npc3, npc4, npc5;
    [SerializeField] Sprite cargo, train;
    TextMeshPro carNumber;
    GameObject dialog, playerDialog;

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

    public IEnumerator EndScene() {
        Debug.Log("Started end scene");
        player.GetComponentInChildren<PlayerExamine>().examining = true;
        yield return new WaitForSeconds(2);
        Destroy(npc1); Destroy(npc2); Destroy(npc3);
        player.transform.position = new Vector2(0.45f,player.transform.position.y);
        npc1 = Instantiate(addict,new Vector2(-9f,-0.80f),transform.rotation,this.transform);
        npc2 = Instantiate(hustler,new Vector2(4f,-0.95f),transform.rotation,this.transform);
        npc2.GetComponent<SpriteRenderer>().flipX = true;
        npc3 = Instantiate(priest,new Vector2(-4f,-0.95f),transform.rotation,this.transform);
        npc4 = Instantiate(parent,new Vector2(-2.25f,-0.95f),transform.rotation,this.transform);
        npc5 = Instantiate(programmer,new Vector2(8f,-0.95f),transform.rotation,this.transform);
        npc5.GetComponent<SpriteRenderer>().flipX = true;
        GameObject.Find("GameManager").GetComponent<Talk>().startEnd = true;
        Fade.RequestFade = true;
        yield return new WaitForSeconds(1);
        dialog.SetActive(true);
        playerDialog.SetActive(true);
        GameObject.Find("GameManager").GetComponent<Talk>().StartDialogue(null);
    }

    IEnumerator ChangeTraincar() {
        Fade.RequestFade = true;
        // Check if we have reached end scene
        if (GameObject.Find("GameManager").GetComponent<Talk>().end == true) {
            traincar = "Car2";
            carNumber.text = "3";
            GetComponent<SpriteRenderer>().sprite = train;
            StartCoroutine(EndScene());
            yield break;
        }

        //Play door soundeffect
        yield return new WaitForSeconds(1);
        MovePlayer();                                       // Move Player to correct side of the train
        Destroy(npc1); Destroy(npc2); Destroy(npc3);        // Destroy all NPCs
        if (traincar == "Car0") {
            carNumber.text = "1";
            GetComponent<SpriteRenderer>().sprite = cargo;
            // Instantiate cargo Objects
            npc1 = Instantiate(sign,new Vector2(7f,-0.40f),transform.rotation,this.transform);

        }
        else if (traincar == "Car1") {
            carNumber.text = "2";
            GetComponent<SpriteRenderer>().sprite = train;
            // Instantiate Traincar 1 NPCs & Objects
            npc1 = Instantiate(parent,new Vector2(-2.11f,-0.95f),transform.rotation,this.transform);              
        }
        else if (traincar == "Car2") {
            carNumber.text = "3";
            // Instantiate Traincar 2 NPCs & Objects
            npc1 = Instantiate(programmer,new Vector2(-7f,-0.95f),transform.rotation,this.transform);  
        }
        else if (traincar == "Car3") {
            carNumber.text = "4";
            // Instantiate Traincar 3 NPCs & Objects
            npc1 = Instantiate(priest,new Vector2(3f,-0.95f),transform.rotation,this.transform);
        }
        else if (traincar == "Car4") {
            carNumber.text = "";
            // Instantiate Traincar 4 NPCs & Objects
            npc1 = Instantiate(addict,new Vector2(-9.07f,-0.79f),transform.rotation,this.transform);
            npc2 = Instantiate(hustler,new Vector2(9.6f,-0.87f),transform.rotation,this.transform);
        }
        Fade.RequestFade = true;
    }
    void Start()
    {
        player = GameObject.Find("Player");
        carNumber = GameObject.Find("TrainCarNumber").GetComponent<TextMeshPro>();
        npc1 = Instantiate(parent,new Vector2(-2.11f,-0.95f),transform.rotation,this.transform);
        dialog = GameObject.Find("DialogueBox");
        playerDialog = GameObject.Find("PlayerDialogueBox");
    }

    void Update()
    {
        player.GetComponentInChildren<PlayerExamine>().screenFade = Fade.IsFading;
        if (traincar == "Car0") {
            if (goNext == true) {
                Debug.Log("Entering Traincar 1");
                traincar = "Car1";
                StartCoroutine(ChangeTraincar());
                goNext = false;
            }
            else if (goPrev == true) {
                Debug.Log("Locked");
                goPrev = false;
            }
        }
        else if (traincar == "Car1") {
            if (goNext == true) {
                Debug.Log("Entering Traincar 2");
                traincar = "Car2";
                StartCoroutine(ChangeTraincar());
                goNext = false;
            }
            else if (goPrev == true) {
                Debug.Log("Entering Cargo");
                traincar = "Car0";
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
                Debug.Log("Locked");
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
