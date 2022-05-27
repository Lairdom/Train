using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Vector2 playerInput;
    float moveSpeed = 4;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hahmon liike
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Mathf.Abs(playerInput.x) > 0) {
            gameObject.GetComponentInChildren<PlayerExamine>().examining = false;
            _animator.Play("PlayerWalk");
        }
        else 
            _animator.Play("PlayerIdle");
                
        if (playerInput.x > 0) {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        else if (playerInput.x < 0) {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }

        //Käännetään sprite ympäri jos liikutaan vasemmalle tai oikealle
        if (playerInput.x < 0) {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (playerInput.x > 0) {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        // Examine
        if (transform.GetComponentInChildren<PlayerExamine>().screenFade != true) {
            if (Input.GetButtonDown("Fire1")) {
                transform.GetComponentInChildren<PlayerExamine>().examine = true;
            }
        }
    }
}
