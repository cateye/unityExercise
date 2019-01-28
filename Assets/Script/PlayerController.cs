using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables definitions
    float walkspeed = 3; //Speed to move the character
    float jumpForce = 4; // Jump force
    bool pressedJump;    //to check if we press the space bar
    Vector3 size;       //Vector for the size of the payer collider

    Rigidbody rb;
    Collider playerCol;
    //Audio
    public AudioSource audioCoin;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCol = GetComponent<Collider>();

        size = playerCol.bounds.size;
    }



    // FixedUpdate is called once per frame
    // We used FixedUpdate instead of Update because we are using physics
    void FixedUpdate()
    {
        walkHandler();
        jumpHandler();

    }
    //walkHandler manage how the player will walk
    void walkHandler()
    {
        //take the input from the keyboard (we can check this property in Project Settings -> input
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        Vector3 Hmovement = new Vector3(walkspeed * -vAxis * Time.deltaTime, 0, walkspeed * hAxis * Time.deltaTime);
        Vector3 newPosition = transform.position += Hmovement;
        //move with rigidBody
        rb.MovePosition(newPosition);
    }

    void jumpHandler()
    {
        float jAxis = Input.GetAxis("Jump");
        //if we press the spacebar
        if (jAxis > 0) {
            if (isGrounded()) { print("Esta tocando el piso"); }
                //we need to check if it was pressed already, and is in the floor.
                if (!pressedJump && isGrounded())
                {
                    pressedJump = true;
                    Vector3 jumpVector = new Vector3(0, jumpForce * jAxis, 0);
                    rb.AddForce(jumpVector, ForceMode.VelocityChange);
                }
            
        }
        else
        {
            pressedJump = false;
        }

    }

    private bool isGrounded()
    {
        Vector3 corner1 = transform.position + new Vector3(size.x / 2, -size.y / 2 + 0.01f, size.z / 2);
        Vector3 corner2 = transform.position + new Vector3(-size.x / 2, -size.y / 2 + 0.01f, size.z / 2);
        Vector3 corner3 = transform.position + new Vector3(size.x / 2, -size.y / 2 + 0.01f, -size.z / 2);
        Vector3 corner4 = transform.position + new Vector3(-size.x / 2, -size.y / 2 + 0.01f, -size.z / 2);

        //check if they are touching another colider
        //using raycast Physics.Raycast

        bool raycast1 = Physics.Raycast(corner1, -Vector3.up, 0.02f);
        bool raycast2 = Physics.Raycast(corner2, -Vector3.up, 0.02f);
        bool raycast3 = Physics.Raycast(corner3, -Vector3.up, 0.02f);
        bool raycast4 = Physics.Raycast(corner4, -Vector3.up, 0.02f);

        return (raycast1 || raycast2 || raycast3 || raycast4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            print("Choque Con un trigger " + other.tag);
            //destroy the coin
            Destroy(other.gameObject);
            //increse count
            GameController.instance.IncreaseScore(1);
            //Play Sound
            audioCoin.Play();
        }

        if (other.CompareTag("Enemy"))
        {
            print("Choque Con un trigger " + other.tag);
            GameController.instance.ResetGame();
        
        }

        if (other.CompareTag("Goal"))
        {
            print("You reached the Goal " + other.tag);
            GameController.instance.increaseLevel();
            //Destroy(other.gameObject);
            //increse count

        }

    }
}
