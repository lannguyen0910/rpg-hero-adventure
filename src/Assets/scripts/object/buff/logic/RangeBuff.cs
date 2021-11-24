using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBuff : Buff
{
    public RangeBuff() : base(Global.RANGE_BUFF_CODE)
    {

    }

    public override void Process(GameObject target)
    {
        WeaponStatus melee = target.GetComponent<WeaponHolder>().GetWeapon(Global.MELEE_WEAPON).gameObject.GetComponent<WeaponStatus>();
        

    }
}
