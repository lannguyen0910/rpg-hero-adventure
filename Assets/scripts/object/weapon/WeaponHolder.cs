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
    float changeDelay = 0;

    void Start()
    {
        status = gameObject.GetComponent<PlayerStatus>();

        // Get weapon props
        weapons = new Weapon[weaponObjects.Length];
        for (int i = 0; i < weapons.Length; ++i)
        {
            weapons[i] = weaponObjects[i].GetComponent<Weapon>();
        }
        weaponObjects[1].SetActive(false);
    }

    void FixedUpdate()
    {
        if (changeDelay > Global.EPS)
        {
            changeDelay -= Time.deltaTime;    
        }
    }

    public void ChangeWeapon()
    {
        if (changeDelay > Global.EPS) return;
        weaponObjects[currentWeapon].SetActive(false);
        currentWeapon = (currentWeapon + 1) % weapons.Length;
        weaponObjects[currentWeapon].SetActive(true);
        changeDelay = 0.5f;
    }

    public int GetCurrentWeaponType()
    {
        return currentWeapon;

    }

    public Weapon GetWeapon(int type)
    {
        return weapons[type];    
    }

    public void ProcessAction(int code)
    {
        weapons[currentWeapon].ProcessAction(code);

    }
}
