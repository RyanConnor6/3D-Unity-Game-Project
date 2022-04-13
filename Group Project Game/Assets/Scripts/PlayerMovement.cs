using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for basic 1st person character movement
public class PlayerMovement : MonoBehaviour
{
    //Character Controller
    public CharacterController playerController;

    //Variables for speed gravity and jump height
    public float speed = 7f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //Variables for checking for ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;

    //Variables for velocity and variable to say whether the player is in air on on ground
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        //If they are velocity is -2
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Get axis in variables
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //If player jumps and is on ground, change velocity to make them jump
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //If player presses left shift, toggle sprint status
        if (Input.GetButtonDown("left shift"))
        {
            speed = 10;
        }
        else if (Input.GetButtonUp("left shift"))
        {
            speed = 7;
        }

        //Add gravity
        velocity.y += gravity * Time.deltaTime;

        //Move player using velocity
        Vector3 move = transform.right * x * speed
            + transform.forward * z * speed
            + transform.up * velocity.y;


        playerController.Move(move * Time.deltaTime);

        //Check if there is any object above player so they dont float when jumping under an object
        if ((playerController.collisionFlags & CollisionFlags.Above) != 0)
        {
            velocity.y = -2f;
        }
    }
}