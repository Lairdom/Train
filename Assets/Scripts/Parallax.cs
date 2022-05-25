using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject TargetObject;
    [SerializeField] float MoveSpeed, BGWidth;

    float Distance;
    // Start is called before the first frame update
    void Start()
    {
        TargetObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Distance = 
            Vector2.Distance(new Vector2(transform.position.x, 0f), 
            new Vector2(TargetObject.transform.position.x, 0f));

        transform.position -= transform.right * MoveSpeed * Time.deltaTime;

        if(Distance > BGWidth){
            transform.position = new Vector3(
                transform.position.x + BGWidth, 
                transform.position.y, transform.position.z);
        }
    }
}
