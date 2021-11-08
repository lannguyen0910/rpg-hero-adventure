using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : EventDealer
{
    // Start is called before the first frame update
    void Start()
    {
        eventCode = 1;
        base.Start();
    }

    public override void process(GameObject source, Collider2D destination)
    {
        if (destination.isTrigger == false && source != destination.gameObject)
        {
            Debug.Log("Hello there!");
            destination.gameObject.GetComponent<DamageTaker>().process(source);
        }
    }
}
