using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerStatus status;
    SpriteRenderer spriteRenderer;

    int[] stateSpeedX = new int[8] { 0, -1, -1, -1, 0, 1, 1, 1 };
    int[] stateSpeedY = new int[8] { -1, -1, 0, 1, 1, 1, 0, -1 };

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        status = gameObject.GetComponent<PlayerStatus>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void setMoveAnim(float speedX, float speedY)
    {
        // Chuan hoa du lieu
        int sX = (speedX > 0 ? 1 : (speedX < 0 ? -1 : 0));
        int sY = (speedY > 0 ? 1 : (speedY < 0 ? -1 : 0));

        anim.SetInteger("speedX", sX);
        anim.SetInteger("speedY", sY);

        // Neu nhan vat dung yen
        if (sX == 0 && sY == 0)
        {
            
        }
        else
        {
            // Tim direction phu hop
            for (int i = 0; i < 8; i++)
            {
                if (stateSpeedX[i] == sX && stateSpeedY[i] == sY)
                {
                    status.curDirection = i;
                    if (status.curDirection > 4)
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
            anim.SetInteger("curDirection", status.curDirection);
        }
    }

    public void setMeleeWeaponAnim(int actionType, float delay)
    {
        // Dieu chinh direction
        int curDirection = status.curDirection;
        if (curDirection > 4)
        {
            curDirection -= (curDirection - 4) * 2;
            transform.localScale = new Vector2(-1 * Math.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
            transform.localScale = new Vector2(Math.Abs(transform.localScale.x), transform.localScale.y);

        anim.SetInteger("curDirection", curDirection);
        anim.SetInteger("weaponType", 0);
        anim.SetInteger("actionType", actionType);
        anim.SetFloat("actionDelay", delay);
    }

}
