using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    // Normal status
    public float healthPoint = 100f;
    public float moveSpeed = 5f;
    public float attackSpeed = 0.66f;

    public int direction = 0;

    Animator anim;
    float actionDelay = 0;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        if (actionDelay > Global.EPS)
        {
            actionDelay -= Time.deltaTime;
            anim.SetFloat("actionDelay", actionDelay);
        }
        else
        {
            anim.SetInteger("actionType", -1);
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
}
