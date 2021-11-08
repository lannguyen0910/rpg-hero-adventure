using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAction : MonoBehaviour
{
    [SerializeField]
    protected int commandCode;

    protected void Start()
    {
        gameObject.GetComponent<Weapon>().addAction(commandCode, this);    
    }

    public abstract void process();
}
