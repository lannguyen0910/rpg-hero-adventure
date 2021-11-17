using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerStatus status;
    SpriteRenderer spriteRenderer;

    const int DIRECTION_COUNT = 8;
    const int DIRECTION_BREAKPOINT = 4;

    int[] stateSpeedX;
    int[] stateSpeedY;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        status = gameObject.GetComponent<PlayerStatus>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        stateSpeedX = new int[DIRECTION_COUNT] { 0, -1, -1, -1, 0, 1, 1, 1 };
        stateSpeedY = new int[DIRECTION_COUNT] { -1, -1, 0, 1, 1, 1, 0, -1 };

    }   

    public void SetMoveAnim(float speedX, float speedY)
    {
        // Normalize
        int sX = (speedX > 0 ? 1 : (speedX < 0 ? -1 : 0));
        int sY = (speedY > 0 ? 1 : (speedY < 0 ? -1 : 0));
        anim.SetInteger("speedX", sX);
        anim.SetInteger("speedY", sY);

        // Find the right direction
        for (int i = 0; i < DIRECTION_COUNT; i++)
        {
            if (stateSpeedX[i] == sX && stateSpeedY[i] == sY)
            {
                status.direction = i;
                if (status.direction > DIRECTION_BREAKPOINT)
                {
                    transform.localScale = new Vector2(-1 * Math.Abs(transform.localScale.x), transform.localScale.y);
                }
                else
                {
                    transform.localScale = new Vector2(Math.Abs(transform.localScale.x), transform.localScale.y);
                }

                break;
            }
        }

        anim.SetInteger("curDirection", status.direction);
        
    }

    public void SetMeleeWeaponAttackAnim(float delay)
    {
        // Adjust direction
        int direction = status.direction;
        if (Global.AdjustDirection(ref direction, DIRECTION_BREAKPOINT))
        {
            transform.localScale = new Vector2(-1 * Math.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(Math.Abs(transform.localScale.x), transform.localScale.y);
        }

        anim.SetInteger("direction", direction);
        anim.SetInteger("weaponType", Global.MELEE_WEAPON);
        anim.SetInteger("actionType", Global.MELEE_ATTACK);
        anim.SetFloat("actionDelay", delay);
    }

}
