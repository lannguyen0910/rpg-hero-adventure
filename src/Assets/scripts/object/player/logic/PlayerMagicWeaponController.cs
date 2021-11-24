using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicWeaponController : MonoBehaviour
{
    WeaponHolder weaponholder;
    PlayerStatus status;
    PlayerAnimation anim;

    int currentAction;

    // Start is called before the first frame update
    void Start()
    {
        weaponholder = gameObject.GetComponent<WeaponHolder>();
        status = gameObject.GetComponent<PlayerStatus>();
        anim = gameObject.GetComponent<PlayerAnimation>();

    }

    // Update is called once per frame
    void Update()
    {
        // Check if holding melee weapon
        if (weaponholder.GetCurrentWeaponType() != Global.MAGIC_WEAPON) return;

        // Check cast fireball input
        if (Global.WEAPON_ACTION_1 == currentAction && Input.GetKeyUp((KeyCode)Global.WEAPON_ACTION_1))
        {
            weaponholder.ProcessAction(Global.WEAPON_ACTION_1);
            anim.SetMagicWeaponCastAnim();
        }
        // Check cast explode input
        else if (Global.WEAPON_ACTION_2 == currentAction && Input.GetKeyUp((KeyCode)Global.WEAPON_ACTION_2))
        {
            weaponholder.ProcessAction(Global.WEAPON_ACTION_2);
            anim.SetMagicWeaponCastAnim();
        }
        // Check cast iceball input
        else if (Global.WEAPON_ACTION_3 == currentAction && Input.GetKeyUp((KeyCode)Global.WEAPON_ACTION_3))
        {
            weaponholder.ProcessAction(Global.WEAPON_ACTION_3);
            anim.SetMagicWeaponCastAnim();
        }

        // Check if doing other action
        if (status.IsDelay()) return;
        
        
        // Check change weapon
        if (Input.GetKeyDown((KeyCode)Global.WEAPON_CHANGE))
        {
            weaponholder.ChangeWeapon();
            return;
        }

        // Check charge fireball input
        if (Input.GetKeyDown((KeyCode)Global.WEAPON_ACTION_1))
        {
            if (weaponholder.ProcessAction(Global.WEAPON_ACTION_1))
            {
                currentAction = Global.WEAPON_ACTION_1;
                anim.SetMagicWeaponChargeAnim();
            }
        }
        // Check charge explode input
        else if (Input.GetKeyDown((KeyCode)Global.WEAPON_ACTION_2))
        {
            if (weaponholder.ProcessAction(Global.WEAPON_ACTION_2))
            {
                currentAction = Global.WEAPON_ACTION_2;
                anim.SetMagicWeaponChargeAnim();
            }
        }
        // Check charge iceball input
        else if (Input.GetKeyDown((KeyCode)Global.WEAPON_ACTION_3))
        {
            if (weaponholder.ProcessAction(Global.WEAPON_ACTION_3))
            {
                currentAction = Global.WEAPON_ACTION_3;
                anim.SetMagicWeaponChargeAnim();
            }
        }

    }
}
