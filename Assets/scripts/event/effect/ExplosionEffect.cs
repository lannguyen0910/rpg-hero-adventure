using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : EventEffect
{
    [SerializeField]
    float explosionDelay = 1.25f;

    new void Start()
    {
        eventCode = Global.EXPLOSION_CODE;
        base.Start();
    }

    public override void Process(GameObject source)
    {
        explosionDelay -= Time.deltaTime;
        if (explosionDelay < Global.EPS)
            Destroy(gameObject);
    }
}
