using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : EventDealer
{
    // Start is called before the first frame update
    void Start()
    {
        eventCode = GlobalConstraints.DAMAGE_CODE;
        base.Start();
    }

    public override void process(GameObject source, Collider2D destination)
    {
        if (destination.isTrigger == false && source != destination.gameObject)
        {
            Debug.Log("Hello " + destination.name);
            try
            {
                destination.gameObject.GetComponent<TakerManager>().getTaker(GlobalConstraints.DAMAGE_CODE).process(source);
            }
            catch (NullReferenceException ex)
            {

            }
        }
    }
}
