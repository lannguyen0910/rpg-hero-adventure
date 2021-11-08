using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    PlayerStatus playerStatus;

    float curSpeedX = 0.0f;
    float curSpeedY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        playerStatus = gameObject.GetComponent<PlayerStatus>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            curSpeedX = -playerStatus.moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            curSpeedX = playerStatus.moveSpeed;
        }
        else
        {
            curSpeedX = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            curSpeedY = playerStatus.moveSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            curSpeedY = -playerStatus.moveSpeed;
        }
        else
        {
            curSpeedY = 0;
        }
    }

    void FixedUpdate()
    {
       rigidbody2d.velocity = new Vector2(curSpeedX, curSpeedY);
    }
}
