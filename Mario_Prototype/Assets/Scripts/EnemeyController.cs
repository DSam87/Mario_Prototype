using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyController : MonoBehaviour
{

    public float moveSpeed;

    public Transform leftPoint, rightPoint;
    public bool movingRight;
    public bool followingPlayer;

    private Rigidbody2D theRB;

    private PlayerController target;
    public float jumpForce;
    public float jumpTimer, jumpTimerDuration;

    public bool isGrounded;

    public GameObject groundPoint;
    public LayerMask groundLayer;

    public Animator anim;

    public float currentPosition, lastPosition;


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>();
        movingRight = true;
        leftPoint.parent = null;
        rightPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position.y;

        // Animation
        if(currentPosition > lastPosition)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
        }
        else if(currentPosition < lastPosition)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }

        isGrounded = Physics2D.OverlapCircle(groundPoint.transform.position, .1f, groundLayer);

        // ////////////////////////////////////////////////////////////////////////////////////
        // Jumping Timer
        // ////////////////////////////////////////////////////////////////////////////////////
        if(jumpTimer <= 0 && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            jumpTimer = jumpTimerDuration;
        }
        else
        {
            theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y);
            jumpTimer -= Time.deltaTime;
        }



        if(!isGrounded)
        {
            // ////////////////////////////////////////////////////////////////////////////////////
            // Looking For Player and Follow Player Or Else Go From Point to Point
            // ////////////////////////////////////////////////////////////////////////////////////
            if(Mathf.Abs(target.transform.position.x - transform.position.x) < 8.5f)
            {
                followingPlayer = true;
                if(target.transform.position.x > transform.position.x)
                {
                    theRB.velocity = new Vector2(moveSpeed * .9f, theRB.velocity.y);
                    transform.localScale = new Vector3(-1,1,1);
                }
                else
                {
                    theRB.velocity = new Vector2(-moveSpeed * .9f, theRB.velocity.y);
                    transform.localScale = new Vector3(1,1,1);
                }
            }
            else
            {
                if(movingRight)
                {
                    theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                    transform.localScale = new Vector3(-1,1,1);
                    if(transform.position.x >= rightPoint.position.x)
                    {
                        movingRight = false;
                    }
                }

                if(!movingRight)
                {
                    theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                    transform.localScale = new Vector3(1,1,1);
                    if(transform.position.x <= leftPoint.position.x)
                    {
                        movingRight = true;
                    }
                }
            }
        }
        lastPosition = transform.position.y;
    }

}
