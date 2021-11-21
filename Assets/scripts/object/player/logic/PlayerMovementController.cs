using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    PlayerStatus status;
    PlayerAnimation anim;

    // Current move speed for each direction
    float speedX = 0f;
    float speedY = 0f;

    // Previous click button for left/right and up/down
    int prevActionX = -1;
    int prevActionY = -1;

    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        status = gameObject.GetComponent<PlayerStatus>();
        anim = gameObject.GetComponent<PlayerAnimation>();
        
    }

    float lastTime = 0;

    void Update()
    {
        // Reset move speed each frame
        speedX = 0f;
        speedY = 0f;

        // Check horizontal move
        CheckMoveInput(Global.MOVE_LEFT, -1, ref speedX, ref prevActionX);
        CheckMoveInput(Global.MOVE_RIGHT, 1, ref speedX, ref prevActionX);
        // Check vertical move
        CheckMoveInput(Global.MOVE_DOWN, -1, ref speedY, ref prevActionY);
        CheckMoveInput(Global.MOVE_UP,    1, ref speedY, ref prevActionY);

        // Check if doing other action
        if (status.IsDelay())
        {
            speedX = 0;
            speedY = 0;
        }

        // Set animation
        anim.SetMoveAnim(speedX, speedY);
        
    }

    void FixedUpdate()
    {
        // Set velocity
        if (!status.IsDashing())
        {
            rigidbody2d.velocity = new Vector2(speedX, speedY);
        }
    }

    private void CheckMoveInput(int code, int sign, ref float speed, ref int prevAction)
    {
        if (Input.GetKeyDown((KeyCode)code) || (Input.GetKey((KeyCode)code) && code == prevAction))
        {
            speed = sign * status.moveSpeed;
            prevAction = code;
        }

    }
}
