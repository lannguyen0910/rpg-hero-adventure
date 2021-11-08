using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : EventTaker
{
    // Start is called before the first frame update
    void Start()
    {
        eventCode = 1;
        base.Start();
    }

    public override void process(GameObject source)
    {
        Debug.Log("Oh hello there!");
    }
}
