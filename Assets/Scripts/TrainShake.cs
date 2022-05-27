using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainShake : MonoBehaviour
{
    float timer, randomTime;

    [SerializeField] GameObject[] Carts;

    IEnumerator Shake() {
        if(BGManager.instance.IsMoving == true){
            for (int i = 0; i<3; i++){
                Carts[i].transform.position = new Vector3(Carts[i].transform.position.x,0.05f);
                yield return new WaitForSeconds(0.2f);
                Carts[i].transform.position = new Vector3(Carts[i].transform.position.x,0);
            }
        }
    }

    void Start()
    {
        randomTime = Random.Range(4,11);
        timer = 0;
    }

    void Update()
    {
        if (timer >= randomTime) {
            randomTime = Random.Range(4,11);
            StartCoroutine(Shake());
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
