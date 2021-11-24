using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBuff : Buff
{
    public RangeBuff() : base(Global.RANGE_BUFF_CODE)
    {
        description = "INCREASE MELEE RANGE";
    }

    public override void Process(GameObject target)
    {
        GameObject hitbox = target.GetComponent<WeaponHolder>().GetWeapon(Global.MELEE_WEAPON).gameObject.GetComponent<WeaponMeleeAttackAction>().hitboxPrototype;

        hitbox.transform.localScale *= 1.2f;
    }
}
