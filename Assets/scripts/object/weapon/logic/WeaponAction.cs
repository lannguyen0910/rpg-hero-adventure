using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAction : MonoBehaviour
{
    [SerializeField]
    protected int code;

    protected void Start()
    {
        gameObject.GetComponent<Weapon>().AddAction(code, this);
    }

    public abstract void Process();

    public void RemoveSelf()
    {
        Destroy(this);
    }
}
