using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTaker : EventTaker
{
    EnemyStatus status;

    protected void Start()
    {
        eventCode = GlobalConstraints.DAMAGE_CODE;
        base.Start();

        status = gameObject.GetComponent<EnemyStatus>();
    }

    public override void process(GameObject source)
    {
        status.health -= 10;
    }
}
