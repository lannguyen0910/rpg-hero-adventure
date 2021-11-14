using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlashEffect : EventEffect
{
    float currentDelay = 0;

    float damage = 0f;
    float delay = 0f;

    EnemyStatus status;

    void Start()
    {
        eventCode = 2;
        base.Start();

        currentDelay = 0;
    }

    public override void process(GameObject source)
    {
        if (status == null)
        {
            status = source.GetComponent<EnemyStatus>();

            damage = status.damage;
            delay = status.attackSpeed;
        }

        currentDelay += Time.deltaTime;

        if (currentDelay >= delay * 30f / 50f)
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }

        if (currentDelay >= delay)
        {
            currentDelay = 0;
            Destroy(gameObject, 0);
        }
    }
}
