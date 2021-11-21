using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTaker : EventTaker
{
    [SerializeField]
    float multiplier = 1;

    EnemyStatus status;

    new protected void Start()
    {
        eventCode = Global.DAMAGE_CODE;
        base.Start();

        status = gameObject.GetComponent<EnemyStatus>();
    }

    public override void Process(GameObject source, VariableDictionary variables)
    {
        status.healthPoint -= (float)variables[Global.DAMAGE_NAME] * multiplier;
    }

    public void SetMultiplier(float multiplier)
    {
        this.multiplier = multiplier;
    }
}
