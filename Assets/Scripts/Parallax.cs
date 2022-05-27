using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject TargetObject;
    [SerializeField] float MoveSpeed, BGWidth;

    float playerInput;

    float Distance;
    // Start is called before the first frame update
    void Start()
    {
        TargetObject = transform.parent.gameObject;
        Invoke("TrainStart", 2f);
        Invoke("TrainStop", 30f);
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = (Input.GetAxisRaw("Horizontal"));
        if (playerInput < 0f) {playerInput = -3;} else if (playerInput > 0f) {playerInput = 2;}
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
