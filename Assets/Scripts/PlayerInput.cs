using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Vector2 playerInput;
    float moveSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Hahmon liike
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (playerInput.x > 0) {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        else if (playerInput.x < 0) {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        // if (playerInput.y > 0) {
        //     transform.position += transform.up * moveSpeed * Time.deltaTime;
        // }
        // else if (playerInput.y < 0) {
        //     transform.position -= transform.up * moveSpeed * Time.deltaTime;
        // }

        //Käännetään sprite ympäri jos liikutaan vasemmalle tai oikealle
        if (playerInput.x < 0) {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (playerInput.x > 0) {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        // Examine
        if (Input.GetButtonDown("Fire1")) {
            transform.GetComponent<PlayerExamine>().examine = true;
        }
    }
}
