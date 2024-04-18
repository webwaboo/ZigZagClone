using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    //var for the trigger of fall anim
    public Transform rayStart;
    private Animator anim;

    private Rigidbody rb;
    private bool walkingRight = true;

    private GameManager gameManager;

    public GameObject crystalEffect;

    // initialize RigidBody, Animator et GameManager
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    
    private void FixedUpdate()
    {
        //check if game is started or not
        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("gameStarted");
        }
        //move the player step by step (via fixed amount of time)
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //switch orientation of character when Space is pressed
        if(Input.GetKeyDown(KeyCode.Space)) {
            Switch();
        }

        RaycastHit hit;
        //If there raycast doesn't hit anything below char, trigger isFalling
        if(!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity)) 
        {
            anim.SetTrigger("isFalling");
        }
        else
        {
            anim.SetTrigger("notFallingAnymore");
        }

        if (transform.position.y < -2) 
        {
            gameManager.EndGame();
        }
        
    }

    //change orientation of char of 45 degree
    private void Switch()
    {
        //can't move if game is not started
        if(!gameManager.gameStarted)
        {
            return;
        }
        //change direction of char with boolean
        walkingRight = !walkingRight;
        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0f, 45f, 0f);
        }
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);
    }

    //Stuff happens when char touch stuff
    private void OnTriggerEnter(Collider other)
    {
        //if object crystal is touched,
        if(other.tag == "Crystal")
        {
            //increase score
            gameManager.IncreaseScore();

            //start and destroy particle effect and crystal
            GameObject g = Instantiate(crystalEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(g, 3);
            Destroy(other.gameObject);
        }
    }
}
