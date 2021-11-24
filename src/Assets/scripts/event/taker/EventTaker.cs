using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventTaker : MonoBehaviour
{
    [SerializeField]
    protected int eventCode;

    protected void Start()
    {
        gameObject.GetComponent<TakerManager>().AddTaker(eventCode, this);
    }

    public abstract void Process(GameObject source, VariableDictionary variables);

    public void RemoveSelf()
    {
        Destroy(this);
    }
}
