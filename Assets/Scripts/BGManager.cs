using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public static BGManager instance;
    public float MoveSpeed = 0;

    float startVal, DestVal, Duration, time;

    public bool IsMoving;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        MoveSpeed = 0;
        DestVal = 0f;
        Duration = 0f;
        time = 0f;
    }

    public void startTrain(){
        MoveSpeed = 0.1f;
        startVal = MoveSpeed;
        DestVal = 1f;
        Duration = 10f;
        time = 0f;
    }

    public void stopTrain(){
        startVal = MoveSpeed;
        DestVal = 0f;
        Duration = 15f;
        time = 0f;
    }

    void Update(){
        IsMoving = MoveSpeed != 0f;
        if(time < Duration){
            time += Time.deltaTime;
            MoveSpeed = Mathf.Lerp(startVal, DestVal, time / Duration);
        }
    }
}
