using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : EventEffect
{
    public float slashDelay = 0.5f;

    float currentDelay = 0;


    void Start()
    {
        eventCode = 2;
        base.Start();

        currentDelay = 0;
    }

    public override void process()
    {
        currentDelay += Time.deltaTime;
        if (currentDelay >= slashDelay)
        {
            currentDelay = 0;
            Destroy(gameObject, 0);
        }
    }
}
