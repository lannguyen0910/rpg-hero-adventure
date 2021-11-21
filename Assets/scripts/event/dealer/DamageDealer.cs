using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : EventDealer
{
    new void Start()
    {
        eventCode = Global.DAMAGE_CODE;
        base.Start();
    }

    public override void Process(GameObject source, Collider2D destination)
    {
        if (!destination.isTrigger && source != destination.gameObject)
        {
            Debug.Log("Hello " + destination.name);
            try
            {
                destination.gameObject.GetComponent<TakerManager>().GetTaker(Global.DAMAGE_CODE).Process(source, variables);
            }
            catch (NullReferenceException) {}
        }
    }

    public void SetDamage(float damage)
    {
        variables[Global.DAMAGE_NAME] = damage;
    }
}
