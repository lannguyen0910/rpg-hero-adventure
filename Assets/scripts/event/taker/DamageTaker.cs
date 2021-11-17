using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : EventTaker
{
    PlayerStatus status;

    // Start is called before the first frame update
    protected void Start()
    {
        eventCode = Global.DAMAGE_CODE;
        status = gameObject.GetComponent<PlayerStatus>();
        base.Start();
    }

    public override void process(GameObject source)
    {
        Debug.Log("Hello there " + source.name);

        EnemyStatus enemyStatus = source.GetComponent<EnemyStatus>();

        status.healthPoint -= enemyStatus.damage;
    }
}
