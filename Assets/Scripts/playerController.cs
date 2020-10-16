using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Public vars
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos; //Position, rotation and scale of an object.
    [SerializeField] private LayerMask whatIsGround;

    // Private vars
    private Rigidbody2D rBody;
    private bool isGrounded = false; //make sure i am not touching the ground initially


    void Start()
    {
        // Catching the rbody
        rBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Return the value of the x axis
        float horizontal = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        //Jump code
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }
        // Accesing the velocity property of the rigidBody and defining in x , y
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y); // feeding the player's y velocity into itself

    }
    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }
}
