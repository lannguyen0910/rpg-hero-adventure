using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMeleeGuardAction : WeaponAction
{
    PlayerStatus playerStatus;

    new void Start()
    {
        code = Global.WEAPON_ACTION_2;
        base.Start();

        playerStatus = gameObject.transform.parent.transform.parent.gameObject.GetComponent<PlayerStatus>();
    }


    public override void Process()
    {
        playerStatus.SetDelay(playerStatus.shieldDelay);
        transform.parent.parent.gameObject.AddComponent<GuardEffect>();
        transform.parent.parent.gameObject.GetComponent<GuardEffect>().SetGuardDelay(playerStatus.shieldDelay);
    }
}
