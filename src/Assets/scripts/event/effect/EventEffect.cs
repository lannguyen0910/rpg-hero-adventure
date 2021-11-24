using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventEffect : MonoBehaviour
{
    [SerializeField]
    protected int eventCode;

    protected void Start()
    {
        gameObject.GetComponent<EffectManager>().AddEffect(eventCode, this);
    }

    public abstract void Process(GameObject source);

    public void RemoveSelf()
    {
        Destroy(this);
    }
}
