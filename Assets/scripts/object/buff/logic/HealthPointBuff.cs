using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointBuff : Buff
{
    public HealthPointBuff() : base(Global.HP_BUFF_CODE)
    {
        
    }

    public override void Process(GameObject target)
    {
        PlayerStatus status = target.GetComponent<PlayerStatus>();

        float hp = status.maxHealthPoint * 0.2f;
        status.maxHealthPoint += hp;
        status.healthPoint += hp;
    }
}
