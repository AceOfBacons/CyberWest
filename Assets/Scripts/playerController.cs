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
    public static playerController instance;
    AudioSource audioSrc;


    // Private vars
    private Rigidbody2D rBody;
    private bool isGrounded = false; //make sure i am not touching the ground initially
    private bool isFacingRight;
    private Animator anim;
    private bool isMoving;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        // Catching the rbody
        rBody = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Return the value of the x axis
        float horizontal = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        //Jump code
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            soundsManager.PlaySound("playerJumpSound");
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }
        // Accesing the velocity property of the rigidBody and defining in x , y
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y); // feeding the player's y velocity into itself

        // Communicate with animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);

        //check if the sprite needs to be flipped
        if ((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
        {
            Flip();
        }


    }
    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }
    private void Flip()
    {
        // Flip player
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    // Platforms logic
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            //Making the player a child
            this.transform.parent = other.transform;
        }
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {

            this.transform.parent = null;
            
        }
    }
}
