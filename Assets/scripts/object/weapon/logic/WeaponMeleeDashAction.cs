using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMeleeDashAction : WeaponAction
{
    PlayerStatus playerStatus;
    Rigidbody2D rigid;

    float[] xSpeedAt = new float[8] {  0f, -0.71f, -1f, -0.71f, 0f, 0.71f, 1f,  0.71f };
    float[] ySpeedAt = new float[8] { -1f, -0.71f,  0f,  0.71f, 1f, 0.71f, 0f, -0.71f };

    new void Start()
    {
        code = Global.WEAPON_ACTION_3;
        base.Start();

        playerStatus = gameObject.transform.parent.transform.parent.gameObject.GetComponent<PlayerStatus>();
        rigid = gameObject.transform.parent.transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }


    public override void Process()
    {
        int direction = playerStatus.direction;

        playerStatus.SetDash(playerStatus.dashDelay);
        rigid.velocity = new Vector2(xSpeedAt[direction] * playerStatus.dashSpeed, ySpeedAt[direction] * playerStatus.dashSpeed);
    }
}
