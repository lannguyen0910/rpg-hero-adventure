using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMeleeAttackAction : WeaponAction
{
    public GameObject slashArea;

    WeaponAnimation anim;
    WeaponStatus weaponStatus;
    PlayerStatus playerStatus;

    void Start()
    {
        commandCode = (int)KeyCode.C;
        base.Start();

        anim = gameObject.GetComponent<WeaponAnimation>();
        weaponStatus = gameObject.GetComponent<WeaponStatus>();
        playerStatus = gameObject.transform.parent.transform.parent.gameObject.GetComponent<PlayerStatus>();
    }

    public override void process()
    {
        int curDirection = playerStatus.curDirection;
        if (curDirection > 4)
            curDirection -= (curDirection - 4) * 2;

        GameObject slashAreaInstance = Instantiate(slashArea, transform.parent);
        slashAreaInstance.transform.parent = gameObject.transform.parent.parent;

        slashAreaInstance.transform.localPosition = new Vector3(0, 0, 0);
        slashAreaInstance.transform.localScale = new Vector3(0.35f, 0.35f, 0);
        slashAreaInstance.transform.Rotate(0, 0, curDirection  * -45);

        slashAreaInstance.GetComponent<Bullet>().source = gameObject.transform.parent.parent.gameObject;

        anim.setWeaponAttackAnim(curDirection);
        playerStatus.actionDelay = 40.0f / 60.0f;
    }
}
