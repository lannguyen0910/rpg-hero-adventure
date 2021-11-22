using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    // Normal status
    public float maxHealthPoint = 50;
    public float healthPoint = 50;
    public float damage = 10;
    public float moveSpeed = 0.025f;
    public float attackSpeed = 0.83f;
    public float attackRange = 1;
    public float detectRange = 3;

    float actionDelay;

    void Update()
    {
        if (healthPoint < Global.EPS)
        {
            // Sound here
            GameObject.Find("Map").GetComponent<Map>().RemovePath(transform.name);
            Destroy(gameObject);
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
