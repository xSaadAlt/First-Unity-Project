//using System.Threading.Tasks.Dataflow;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class Player : MonoBehaviour  
{

public UnityEngine.UI.Slider healthBar;
public int maxhealth = 100;
public GameObject AttachHitBox;
public int currentHealth;

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
        currentHealth = maxhealth;
        healthBar.maxValue = maxhealth;
        healthBar.value = currentHealth;
    }


    public void takeDamge(int damgeAmount)
    {
        currentHealth -=damgeAmount;
        healthBar.value = currentHealth;
        Debug.Log("Take Damge! : " + damgeAmount);

        if (currentHealth <= 0)
        {
            Debug.Log("Die");
            healthBar.value = 0;
            Destroy(gameObject);
        }
    }

    void _jump()
    

    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        float _verticalinput = Input.GetAxisRaw("Vertical");
        //bool _isJumping = false;
         if (isGrounded)
        {
            CanDoubleJump = true;
           // _isJumping = false;
            _animator.SetBool("isJump", false);
        }

    if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
           // _animator.SetBool("isJump", true);
            //rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpspeed);
            rb.AddForce(Vector2.up*jumpspeed, ForceMode2D.Impulse);
          //  _isJumping = true;

            }else if (CanDoubleJump)
            {
            //rb.linearVelocity = new Vector2(rb.linearVelocityX,DoubleJumpspeed);
            rb.AddForce(Vector2.up*DoubleJumpspeed,ForceMode2D.Impulse);
            Instantiate(doublejumpEffect,JumpEffect.position,Quaternion.identity);
            CanDoubleJump = false;
        //    _isJumping = true;
            }
        }

       // if (_isJumping == false && transform.position.y < -5)
      //  {
      //      transform.position = new Vector3(2,2,0);
       // }
        

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
        AttachHitBox.SetActive(true);
        nextattacktime = Time.time + attackcooldown;
        Invoke(nameof(StopAttack), 0.2f); // يطفّى بعد 0.2 ثانية
        }
    }

    void StopAttack()
    {
        AttachHitBox.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        _jump();
          _movement();
          _attack();

    }



}
