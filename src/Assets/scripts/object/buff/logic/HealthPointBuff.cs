using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointBuff : Buff
{
    public HealthPointBuff() : base(Global.HP_BUFF_CODE)
    {
        description = "INCREASE HEALTH";
    }

    public override void Process(GameObject target)
    {
        PlayerStatus status = target.GetComponent<PlayerStatus>();

        float hp = status.maxHealthPoint * 0.5f;
        status.maxHealthPoint += hp;
        status.healthPoint += hp;
    }
}
