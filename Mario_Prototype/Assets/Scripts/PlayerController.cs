using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float playerSpeed;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDubleJump;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("playerSpeed", Mathf.Abs(theRB.velocity.x));
        if(theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if(theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }



        
    }
}
