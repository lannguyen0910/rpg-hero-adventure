using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventEffect : MonoBehaviour
{
    [SerializeField]
    protected int eventCode;

    protected void Start()
    {
        gameObject.GetComponent<EffectManager>().addEffect(eventCode, this);
    }

    public abstract void process();
}
