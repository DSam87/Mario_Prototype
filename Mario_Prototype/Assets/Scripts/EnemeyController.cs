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
        if(Mathf.Abs(target.transform.position.x - transform.position.x) < 7f)
        {
            followingPlayer = true;
            if(target.transform.position.x > transform.position.x)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                transform.localScale = new Vector3(-1,1,1);
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
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
}
