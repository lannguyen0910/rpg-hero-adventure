using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    // Normal status
    public float maxHealthPoint = 50;
    public float healthPoint = 50;
    public float damage = 10;
    public float moveSpeed = 0.035f;
    public float attackSpeed = 1f;
    public float attackRange = 1.5f;
    public float detectRange = 3;
    // Animation status
    public float readySpeed = 0.5f;
    public float slashSpeed = 0.2f;
    public int direction = 0;
    public int actionType = 0;

    float actionDelay;

    Animator anim;
    EffectManager effects;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        effects = gameObject.GetComponent<EffectManager>();
    }

    void Update()
    {
        if (healthPoint < Global.EPS)
        {
            // Sound here
            GameObject.Find("Map").GetComponent<Map>().RemovePath(transform.name);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        actionDelay -= Time.deltaTime;

        if (actionDelay < 0.2f)
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
        actionDelay = delay + 0.2f;
    }
}
