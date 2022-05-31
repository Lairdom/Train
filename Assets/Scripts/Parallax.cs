using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject TargetObject;
    [SerializeField] float MoveSpeed, BGWidth;

    PlayerInput PlayerInputs;

    float playerInput;

    float Distance;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInputs = GameObject.Find("Player").GetComponent<PlayerInput>();
        TargetObject = transform.parent.gameObject;
        Invoke("TrainStart", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = PlayerInputs.playerInput.x;//(Input.GetAxisRaw("Horizontal"));
        if(Fade.IsFading == false && GameObject.Find("DialogueBox") == null){
            if (playerInput < 0f) {
                playerInput = -3;
            } else if (playerInput > 0f) {
                playerInput = 2;
            }
        } else {
            playerInput = 0f;
        }

        Distance = 
            Vector2.Distance(new Vector2(transform.position.x, 0f), 
            new Vector2(TargetObject.transform.position.x, 0f));

        transform.position -= transform.right * 
        ((MoveSpeed + -playerInput)  * BGManager.instance.MoveSpeed) 
        * Time.deltaTime;

        if(Distance > BGWidth){
            transform.position = new Vector3(
                transform.position.x + BGWidth, 
                transform.position.y, transform.position.z);
        }
    }

    void TrainStart(){
        BGManager.instance.startTrain();
    }

    void TrainStop(){
        BGManager.instance.stopTrain();
    }
}
