using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEffect : EventEffect
{
    [SerializeField]
    float guardDelay = 0;
    float maxDelay = 0;

    PlayerDamageTaker damageTaker = null;

    new void Start()
    {
        eventCode = Global.GUARD_CODE;
        base.Start();
    }

    public override void Process(GameObject source)
    {
        if (damageTaker == null) damageTaker = gameObject.GetComponent<PlayerDamageTaker>();

        guardDelay -= Time.deltaTime;
        if (guardDelay < Global.EPS)
        {
            damageTaker.SetMultiplier(1);
            gameObject.GetComponent<EffectManager>().RemoveEffect(eventCode);
        }
        else
            damageTaker.SetMultiplier((maxDelay - guardDelay) / maxDelay);
    }

    public void SetGuardDelay(float delay)
    {
        guardDelay = delay;
        maxDelay = delay;
    }
}