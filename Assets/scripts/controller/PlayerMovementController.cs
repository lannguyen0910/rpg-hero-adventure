using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    PlayerStatus playerStatus;
    PlayerAnimation anim;

    float curSpeedX = 0.0f;
    float curSpeedY = 0.0f;
    int prevActionX = -1;
    int prevActionY = -1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        playerStatus = gameObject.GetComponent<PlayerStatus>();
        anim = gameObject.GetComponent<PlayerAnimation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        curSpeedX = 0;
        curSpeedY = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.LeftArrow) && (int)KeyCode.LeftArrow == prevActionX))
        {
            curSpeedX = -playerStatus.moveSpeed;
            prevActionX = (int)KeyCode.LeftArrow;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKey(KeyCode.RightArrow) && (int)KeyCode.RightArrow == prevActionX))
        {
            curSpeedX = playerStatus.moveSpeed;
            prevActionX = (int)KeyCode.RightArrow;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKey(KeyCode.UpArrow) && (int)KeyCode.UpArrow == prevActionY))
        {
            curSpeedY = playerStatus.moveSpeed;
            prevActionY = (int)KeyCode.UpArrow;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKey(KeyCode.DownArrow) && (int)KeyCode.DownArrow == prevActionY))
        {
            curSpeedY = -playerStatus.moveSpeed;
            prevActionY = (int)KeyCode.DownArrow;
        }

        if (playerStatus.actionDelay > 0)
        {
            curSpeedX = 0;
            curSpeedY = 0;
        }

        anim.setMoveAnim(curSpeedX, curSpeedY);
        
    }

    void FixedUpdate()
    {
       rigidbody2d.velocity = new Vector2(curSpeedX, curSpeedY);
    }
}
