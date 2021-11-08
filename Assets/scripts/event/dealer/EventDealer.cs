using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventDealer : MonoBehaviour
{
    [SerializeField]
    protected int eventCode;

    protected void Start()
    {
        gameObject.GetComponent<DealerManager>().addDealer(eventCode, this);
    }

    public abstract void process(GameObject source, Collider2D destination);
}
