using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Dictionary<int, WeaponAction> weaponActionDict;

    private void Awake()
    {
        weaponActionDict = new Dictionary<int, WeaponAction>();
    }

    public void addAction(int commandCode, WeaponAction action)
    {
        weaponActionDict.Add(commandCode, action);
    }

    public void processCommand(int code)
    {
        if (weaponActionDict.ContainsKey(code))
        {
            weaponActionDict[code].process();
        }
    }
}
