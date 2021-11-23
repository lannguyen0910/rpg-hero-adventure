using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    // Normal status
    public float maxHealthPoint = 100f;
    public float healthPoint = 100f;
    public float moveSpeed = 5f;
    // Melee status
    public float attackSpeed = 0.66f;
    public float readySpeed = 0.25f;
    public float slashSpeed = 0.17f;
    public float shieldDelay = 1f;
    public float dashSpeed = 15f;
    public float dashDelay = 0.1f;
    // Magic status
    public float chargeSpeed = 1.0f;
    public float chargeDelay = 0.2f;
    public float castDelay = 0.2f;
    // Movement status
    public int direction = 0;
    public int actionType = -1;
    // Other status
    float actionDelay = 0;
    bool isDashing = false;
    float dashCooldown = 0;

    Animator anim;
    Rigidbody2D rigid;
    EffectManager effects;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        effects = gameObject.GetComponent<EffectManager>();
    }

    void FixedUpdate()
    {
        effects.Process(gameObject);

        dashCooldown -= Time.deltaTime;
        actionDelay -= Time.deltaTime;

        if (actionDelay < Global.EPS)
        {
            anim.SetInteger("actionType", -1);
            
            if (isDashing)
            {
                rigid.velocity = new Vector2(0, 0);
                isDashing = false;
                dashCooldown = 1f;
            }
        }
    }

    public bool IsDelay()
    {
        return actionDelay > Global.EPS;
    }

    public void SetDelay(float delay)
    {
        actionDelay = delay;
    }

    public void SetDash(float delay)
    {
        actionDelay = delay;
        isDashing = true;
    }

    public bool IsDashing()
    {
        return isDashing;
    }

    public bool IsAbleToDash()
    {
        return dashCooldown < Global.EPS;
    }

}
