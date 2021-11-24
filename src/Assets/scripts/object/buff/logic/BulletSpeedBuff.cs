using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedBuff : Buff
{
    public BulletSpeedBuff() : base(Global.BULLET_SPEED_BUFF_CODE)
    {
        description = "MAGIC GOES FASTER";
    }

    public override void Process(GameObject target)
    {
        GameObject bullet = target.GetComponent<WeaponHolder>().GetWeapon(Global.MAGIC_WEAPON).gameObject.GetComponent<WeaponMagicFireAction>().bulletPrototype;

        ((BulletEffect)(bullet.GetComponent<EffectManager>().GetEffect(Global.BULLET_CODE))).moveSpeed *= 1.3f;
    }
}
