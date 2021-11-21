using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : Buff
{
    public DamageBuff() : base(Global.DAMAGE_BUFF_CODE)
    {

    }

    public override void Process(GameObject target)
    {
        WeaponStatus melee = target.GetComponent<WeaponHolder>().GetWeapon(Global.MELEE_WEAPON).gameObject.GetComponent<WeaponStatus>();
        WeaponStatus magic = target.GetComponent<WeaponHolder>().GetWeapon(Global.MAGIC_WEAPON).gameObject.GetComponent<WeaponStatus>();

        melee.damage *= 1.2f;
        magic.damage *= 1.1f;
    }
}

