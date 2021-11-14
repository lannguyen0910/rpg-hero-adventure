using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Animation : MonoBehaviour
{
    Animator anim;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void resetAnim()
    {
        anim.SetInteger("actionType", -1);
    }

    public void setMoveAnim(int direction)
    {
        if (direction == 3)
        {
            direction = 1;
            spriteRenderer.flipX = true;
        }
        else
            spriteRenderer.flipX = false;

        anim.SetInteger("actionType", 0);
        anim.SetInteger("direction", direction);
    }

    public void setAttackAnim(int direction)
    {
        if (direction == 3)
        {
            direction = 1;
            spriteRenderer.flipX = true;
        }
        else
            spriteRenderer.flipX = false;

        anim.SetInteger("actionType", 1);
        anim.SetInteger("direction", direction);
    }
}
