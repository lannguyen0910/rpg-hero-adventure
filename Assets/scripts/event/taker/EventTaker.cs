using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventTaker : MonoBehaviour
{
    [SerializeField]
    protected int eventCode;

    protected void Start()
    {
        gameObject.GetComponent<TakerManager>().addTaker(eventCode, this);
    }

    public abstract void process(GameObject source);
}
