using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public GameObject[] weaponObjects;

    PlayerStatus playerStatus;

    Weapon[] weapons;
    int currentWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = gameObject.GetComponent<PlayerStatus>();

        weapons = new Weapon[weaponObjects.Length];

        for (int i = 0; i < weapons.Length; ++i)
        {
            weapons[i] = weaponObjects[i].GetComponent<Weapon>();
        }
    }
    
    public void changeWeapon()
    {
        currentWeapon = (currentWeapon + 1) % weapons.Length;
    }

    public int getCurrentWeapon()
    {
        return currentWeapon;
    }

    public void processCommand(int code)
    {
        weapons[currentWeapon].processCommand(code);
    }
}
