using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : EventDealer
{
    // Start is called before the first frame update
    void Start()
    {
        eventCode = Global.DAMAGE_CODE;
        base.Start();
    }

    public override void Process(GameObject source, Collider2D destination)
    {
        if (destination.isTrigger == false && source != destination.gameObject)
        {
            Debug.Log("Hello " + destination.name);
            try
            {
                destination.gameObject.GetComponent<TakerManager>().GetTaker(Global.DAMAGE_CODE).Process(source);
            }
            catch (NullReferenceException ex)
            {

            }
        }
    }
}
