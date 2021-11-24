using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    void Awake()
    {
        try
        {
            PlayerStorage.LoadData();
            PlayerStorage.SaveData();
        }
        catch (Exception)
        {
            PlayerStorage.SaveData();
        }

        GameObject meleePrefab = Resources.Load("prefabs/weapon/Melee" + PlayerStorage.melee) as GameObject;
        GameObject melee = Instantiate(meleePrefab, player.transform.Find("Weapon"));
        melee.name = "Melee";
        if (PlayerStorage.meleeSkill > 0) melee.GetComponent<WeaponMeleeAttackAction>().enabled = true;
        if (PlayerStorage.meleeSkill > 1) melee.GetComponent<WeaponMeleeGuardAction>().enabled = true;
        if (PlayerStorage.meleeSkill > 2) melee.GetComponent<WeaponMeleeDashAction>().enabled = true;
        player.GetComponent<PlayerAnimation>().meleeWeapon = melee;
        player.GetComponent<WeaponHolder>().weaponObjects[0] = melee;

        GameObject magicPrefab = Resources.Load("prefabs/weapon/Magic" + PlayerStorage.magic) as GameObject;
        GameObject magic = Instantiate(magicPrefab, player.transform.Find("Weapon"));
        magic.name = "Magic";
        if (PlayerStorage.magicSkill > 0) magic.GetComponent<WeaponMagicFireAction>().enabled = true;
        if (PlayerStorage.magicSkill > 1) magic.GetComponent<WeaponMagicExplodeAction>().enabled = true;
        if (PlayerStorage.magicSkill > 2) magic.GetComponent<WeaponMagicIceAction>().enabled = true;
        player.GetComponent<PlayerAnimation>().magicWeapon = magic;
        player.GetComponent<WeaponHolder>().weaponObjects[1] = magic;

        BuffManager.Reset();
    }
}
