using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMeleeAttackAction : WeaponAction
{
    public GameObject bullet;

    void Start()
    {
        commandCode = (int)KeyCode.C;
        base.Start();
    }

    public override void process()
    {
        GameObject b = Instantiate(bullet, GameObject.Find("Player").transform.position, Quaternion.identity);
        b.GetComponent<Bullet>().setSource(GameObject.Find("Player"));
    }
}
