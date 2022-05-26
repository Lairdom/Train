using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTraincar : MonoBehaviour
{
    public string traincar;
    public bool goNext = false, goPrev = false;
    [SerializeField] GameObject addict, hustler, parent, programmer, priest;
    GameObject player, npc1, npc2, npc3;
    SpriteRenderer blackScreen;
    float fadeTimer;
    bool fadeOut = false, fadeIn = false;

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
        fadeOut = true;                                     // Fadeout
        fadeTimer = 0;
        //Play door soundeffect
        yield return new WaitForSeconds(1);
        MovePlayer();                                       // Move Player to correct side of the train
        Destroy(npc1); Destroy(npc2); Destroy(npc3);        // Destroy all NPCs
        if (traincar == "Car1") {
            // Instantiate Traincar 1 NPCs & Objects
        }
        else if (traincar == "Car2") {
            // Instantiate Traincar 2 NPCs & Objects
            npc1 = Instantiate(parent,new Vector2(-2.11f,-0.95f),transform.rotation,transform.parent);              
        }
        else if (traincar == "Car3") {
            // Instantiate Traincar 3 NPCs & Objects
        }
        else if (traincar == "Car4") {
            // Instantiate Traincar 4 NPCs & Objects
            npc1 = Instantiate(addict,new Vector2(-9.07f,-0.79f),transform.rotation,transform.parent);
            npc2 = Instantiate(hustler,new Vector2(9.6f,-0.87f),transform.rotation,transform.parent);
        }
        fadeIn = true;                                     // Fadein
        fadeTimer = 0;
    }
    void Start()
    {
        player = GameObject.Find("Player");
        blackScreen = GameObject.Find("Blackscreen").GetComponent<SpriteRenderer>();
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
                Debug.Log("Locked");
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

        // Lerp FadeOut and FadeIn
        if (fadeOut == true) {
            blackScreen.color = new Color(0,0,0,Mathf.Lerp(0,1,fadeTimer));
            if (blackScreen.color.a == 1) {
                fadeOut = false;
            }
        }
        else if (fadeIn == true) {
            blackScreen.color = new Color(0,0,0,Mathf.Lerp(1,0,fadeTimer));
            if (blackScreen.color.a == 0) {
                fadeIn = false;
            }
        }
        fadeTimer += Time.deltaTime *5;
    }
}
