using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleEffect : EventEffect
{
    [SerializeField]
    float invincibleDelay = 0;

    new void Start()
    {
        eventCode = Global.INVINCIBLE_CODE;
        base.Start();
    }

    public override void Process(GameObject source)
    {
        invincibleDelay -= Time.deltaTime;
        if (invincibleDelay < Global.EPS)
        {
            gameObject.GetComponent<EffectManager>().RemoveEffect(eventCode);
        }
    }

    public void SetInvincibleDelay(float delay)
    {
        invincibleDelay = delay;
    }
}