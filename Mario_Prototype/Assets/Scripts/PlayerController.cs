using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;


    public Rigidbody2D theRB;
    public float playerSpeed;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDubleJump;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private Animator anim;


    private void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if(knockBackCounter <= 0)
        {
            // /////////////////////////////////////////////
            // Moving Player
            // /////////////////////////////////////////////
            theRB.velocity = new Vector2(playerSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            // /////////////////////////////////////////////
            // Player Jumping
            // /////////////////////////////////////////////
            if(Input.GetButtonDown("Jump"))
            {
                if(isGrounded)
                {
                    isGrounded = false;
                    canDubleJump = true;
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
                else if(canDubleJump)
                {
                    canDubleJump = false;
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
            }

            // /////////////////////////////////////////////
            // Animator Player Jumping & Running
            // /////////////////////////////////////////////

            if(theRB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1,1,1);
            }
            else if(theRB.velocity.x > 0)
            {
                transform.localScale = new Vector3(1,1,1);
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if(transform.localScale.x == 1)
            {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }
            if(transform.localScale.x == -1)
            {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }
        }

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("playerSpeed", Mathf.Abs(theRB.velocity.x));
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce*2);
        anim.SetTrigger("isHurt");


    }
}
