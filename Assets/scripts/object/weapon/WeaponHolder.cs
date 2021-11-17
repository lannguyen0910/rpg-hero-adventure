using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weaponObjects;

    PlayerStatus status;

    Weapon[] weapons;
    int currentWeapon = 0;

    void Start()
    {
        status = gameObject.GetComponent<PlayerStatus>();

        // Get weapon props
        weapons = new Weapon[weaponObjects.Length];
        for (int i = 0; i < weapons.Length; ++i)
        {
            weapons[i] = weaponObjects[i].GetComponent<Weapon>();
        }

    }
    
    public void ChangeWeapon()
    {
        currentWeapon = (currentWeapon + 1) % weapons.Length;

    }

    public int GetCurrentWeapon()
    {
        return currentWeapon;

    }

    public void ProcessAction(int code)
    {
        weapons[currentWeapon].ProcessAction(code);

    }
}
