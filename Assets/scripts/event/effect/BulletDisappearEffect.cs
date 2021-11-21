using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisappearEffect : EventEffect
{
    [SerializeField]
    float destroyDelay = 0.05f;

    new void Start()
    {
        eventCode = Global.BULLET_DISAPPEAR_CODE;
        base.Start();
    }

    public override void Process(GameObject source)
    {
        destroyDelay -= Time.deltaTime;
        if (destroyDelay < Global.EPS)
            Destroy(gameObject);
    }
}
