using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float maxHealthPoint = 50;
    public float healthPoint = 50;
    public float damage = 10;
    public float moveSpeed = 0.5f;
    public float attackSpeed = 50f / 60f;

    public float actionDelay;
    public float detectDistance = 7;

    void Update()
    {
        if (healthPoint < Global.EPS)
            Destroy(gameObject);
    }
}
