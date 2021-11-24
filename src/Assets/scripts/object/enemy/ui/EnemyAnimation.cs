using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    EnemyStatus status;
    Animator anim;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        status = gameObject.GetComponent<EnemyStatus>();
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void ResetAnim()
    {
        anim.SetInteger("actionType", -1);
    }

    public void SetMoveAnim(int direction)
    {
        if (direction == 3)
        {
            direction = 1;
            transform.localScale = new Vector2(-1 * Math.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
            transform.localScale = new Vector2(Math.Abs(transform.localScale.x), transform.localScale.y);

        anim.SetInteger("actionType", 0);
        anim.SetInteger("direction", direction);
    }

    public void SetAttackAnim(int direction)
    {
        if (direction == 3)
        {
            direction = 1;
            transform.localScale = new Vector2(-1 * Math.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
            transform.localScale = new Vector2(Math.Abs(transform.localScale.x), transform.localScale.y);

        anim.SetInteger("actionType", 1);
        anim.SetInteger("direction", direction);
    }
}
