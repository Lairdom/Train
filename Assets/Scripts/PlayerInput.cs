using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 playerInput;
    float moveSpeed = 10;
    Animator _animator;
    PlayerExamine examine;
    float stepDelay;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        examine = GetComponentInChildren<PlayerExamine>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hahmon liike
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Mathf.Abs(playerInput.x) > 0 && Fade.IsFading == false && examine.examining == false) {
            _animator.Play("PlayerWalk");
            if (stepDelay > 1) {
                GetComponent<AudioSource>().Play();
                stepDelay = 0;
            }
            stepDelay += Time.deltaTime;
        }
        else 
            _animator.Play("PlayerIdle");
        if(Fade.IsFading == false && examine.examining == false){
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
        }

        // Examine
        if (transform.GetComponentInChildren<PlayerExamine>().screenFade != true) {
            if (Input.GetButtonDown("Fire1")) {
                transform.GetComponentInChildren<PlayerExamine>().examine = true;
            }
        }
    }
}
