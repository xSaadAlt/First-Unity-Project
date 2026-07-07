//using System.Threading.Tasks.Dataflow;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

public float speed = 5f;

    public float attackcooldown = 0.5f;
    public float nextattacktime = 0f;

public Transform groundCheck;
    public GameObject doublejumpEffect;
    public GameObject AttackEffect;
    public Transform JumpEffect;
    public Transform attackPoint;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool isGrounded;
    public bool CanDoubleJump;
    public Rigidbody2D rb;
    public float jumpspeed = 5f;
    public float DoubleJumpspeed = 2f;
    public Animator _animator;
    void Start()
    {
        
    }

    void _jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        float _verticalinput = Input.GetAxisRaw("Vertical");

         if (isGrounded)
        {
            CanDoubleJump = true;
            _animator.SetBool("isJump", false);
        }

    if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
            _animator.SetBool("isJump", true);
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpspeed);

            }else if (CanDoubleJump)
            {
            rb.linearVelocity = new Vector2(rb.linearVelocityX,DoubleJumpspeed);
            Instantiate(doublejumpEffect,JumpEffect.position,Quaternion.identity);
            CanDoubleJump = false;
            }
        }

    }

    void _movement()


    {


        float move = Input.GetAxis("Horizontal");   
        transform.Translate(Vector2.right*move*speed*Time.deltaTime);

        if (move > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }else if (move < 0)
        {
            transform.localScale = new Vector3(-1,1,-1);
        }

        if(move != 0 )
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning",false);
        }

    }

    void _attack()
    {


        if(Input.GetMouseButtonDown(0)&& Time.time >= nextattacktime ){
        Instantiate(AttackEffect,attackPoint.position,Quaternion.identity);
        nextattacktime = Time.time + attackcooldown;
        }
    }

    // Update is called once per frame
    void Update()
    {

        _jump();
          _movement();
          _attack();

    }



}
