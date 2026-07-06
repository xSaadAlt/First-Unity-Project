using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{


public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool isGrounded;
    public bool CanDoubleJump;

    public float speed = 5f;
    public Rigidbody2D rb;
    public float jumpspeed = 5f;
    public float DoubleJumpspeed = 2f;
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {

        if (isGrounded)
        {
            CanDoubleJump = true;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);

        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
        } else if (Input.GetKey(KeyCode.A)) {
rb.linearVelocity = new Vector2(-speed, rb.linearVelocityY);        }

    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpspeed);
        } else if (Input.GetKeyDown(KeyCode.Space)&&CanDoubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX,DoubleJumpspeed);
            CanDoubleJump = false;
        }
    }



}
