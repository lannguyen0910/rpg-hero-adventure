using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float health = 50;
    public float damage = 10;
    public float moveSpeed = 2;
    public float attackSpeed = 50f / 60f;
    public float actionDelay;
    public float detectDistance = 7;
}
