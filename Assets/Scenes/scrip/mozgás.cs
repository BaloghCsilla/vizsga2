using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mozgás : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float Move;
    public float GroundCheckRadius;
    public Transform Groundcheck;

    Animator anim;
    [SerializeField] bool isMoving;
    
    public Rigidbody2D rb;
    public bool groundDetected;
    
    public LayerMask whatIsGround;
   
    [SerializeField] bool áll = true;

    public TMP_Text WINTEXT;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        CollisionChecks();

             
        Move = Input.GetAxis("Horizontal");

        animationController();

        Movement();
        
        changeGravity();

        if (Input.GetKeyDown(KeyCode.Space))
            jump();     

       
    }

    void jump()
    {
        if(groundDetected)
               
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                
    }


    void changeGravity()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.gravityScale *= -1;
            jumpForce *= -1;
            FlipController();
        }

    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Groundcheck.position, GroundCheckRadius);
    }

    void CollisionChecks()
    {
        groundDetected = Physics2D.OverlapCircle(Groundcheck.position, GroundCheckRadius, whatIsGround);        
    }

    

    void Movement()
    {
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        if (rb.velocity.x != 0)
            isMoving = true;
        else isMoving = false;
        
    }

    public void animationController()
    {
        anim.SetBool("isMoving", isMoving);
    }

    void Flip() 
    {
        transform.Rotate(180,0,0);
        áll = !áll;
    }

    void FlipController() 
    {
        if (áll == false) 
        {
            Flip();
        }

        else if (áll == true)
        {
            Flip();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WIN") 
        {
            WINTEXT.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}


    



