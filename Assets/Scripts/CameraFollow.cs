using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player != null) {
            transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
        }
    }
}
