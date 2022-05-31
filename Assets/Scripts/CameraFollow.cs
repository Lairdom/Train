using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player, target;
    Talk talk;

    void Start()
    {
        player = GameObject.Find("Player");
        talk = GameObject.Find(("GameManager")).GetComponent<Talk>();
        target = player;
    }

    void Update()
    {
        target = talk.target;
        if (player != null && talk.startEnd == false) {
            transform.position = new Vector3(player.transform.position.x,transform.position.y,-10);
        }
        else if (player != null && talk.startEnd == true) {
            if(target.name != "Doors")
                transform.position = new Vector3(target.transform.position.x,transform.position.y,-10);
            else
                transform.position = new Vector3(target.transform.position.x + 0.14f,transform.position.y,-10);
        }
    }
}
