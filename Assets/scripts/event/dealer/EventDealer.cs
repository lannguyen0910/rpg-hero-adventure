using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventDealer : MonoBehaviour
{
    [SerializeField]
    protected int eventCode;
    [SerializeField]
    protected VariableDictionary variables = new VariableDictionary();

    protected void Start()
    {
        gameObject.GetComponent<DealerManager>().AddDealer(eventCode, this);
    }

    public abstract void Process(GameObject source, Collider2D destination);

    public void RemoveSelf()
    {
        Destroy(this);
    }
}
