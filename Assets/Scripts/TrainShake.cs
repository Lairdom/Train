using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainShake : MonoBehaviour
{
    float timer, randomTime;

    IEnumerator Shake() {
        gameObject.transform.position = new Vector3(0,0.05f);
        yield return new WaitForSeconds(0.2f);
        gameObject.transform.position = new Vector3(0,0);
    }

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        randomTime = Random.Range(8,15);
        if (timer >= randomTime) {
            StartCoroutine(Shake());
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
