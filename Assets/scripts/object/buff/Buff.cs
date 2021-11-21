using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff
{
    protected int code;

    public Buff(int code)
    {
        this.code = code;
        BuffManager.AddBuff(code, this);
    }

    public abstract void Process(GameObject target);
}
