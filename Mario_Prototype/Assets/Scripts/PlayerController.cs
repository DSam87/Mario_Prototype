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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // /////////////////////////////////////////////
        // Moving Player
        // /////////////////////////////////////////////
        theRB.velocity = new Vector2(playerSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                isGrounded = false;
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
        }



        
    }
}
