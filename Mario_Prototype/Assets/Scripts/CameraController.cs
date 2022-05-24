using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Transform farBackground, middleBackground;
    private float lastXPos;
    private float lastYPos;

    public float minHight, maxHight;
    private Vector2 lastPos;


    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHight, maxHight), transform.position.z);
        
        // Getting the diffrance the player has moved from its last position
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        // Move backgrounds based on how much the player has moved since last position
        farBackground.position += new Vector3(amountToMove.x, amountToMove.y ,0f);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

        // ////////////////////////////////////////////////////////////////////////////////////
        // Max and Min Cam Hight
        // ////////////////////////////////////////////////////////////////////////////////////


        // ////////////////////////////////////////////////////////////////////////////////////
        // set last position for next frame execution
        // ////////////////////////////////////////////////////////////////////////////////////
        lastPos = transform.position;
    }
}
