using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : EventTaker
{
    // Start is called before the first frame update
    protected void Start()
    {
        eventCode = GlobalConstraints.DAMAGE_CODE;
        base.Start();
    }

    public override void process(GameObject source)
    {
        Debug.Log("Oh hello there!");
    }
}
