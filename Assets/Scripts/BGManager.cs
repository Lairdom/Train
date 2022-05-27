using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public static BGManager instance;
    public float MoveSpeed = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        MoveSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTrain(){

    }

    public void stopTrain(){

    }

    void Lerpfunction(){

    }
}
