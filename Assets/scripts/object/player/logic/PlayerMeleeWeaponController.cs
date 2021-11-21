using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeWeaponController : MonoBehaviour
{
    WeaponHolder weaponholder;
    PlayerStatus status;
    PlayerAnimation anim;

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
        if (weaponholder.GetCurrentWeaponType() != Global.MELEE_WEAPON) return;
        // Check if doing other action
        if (status.IsDelay()) return;
        // Check change weapon
        if (Input.GetKeyDown((KeyCode)Global.WEAPON_CHANGE))
        {
            weaponholder.ChangeWeapon();
            return;
        }

        // Check attack input
        if (Input.GetKeyDown((KeyCode)Global.WEAPON_ACTION_1))
        {
            weaponholder.ProcessAction(Global.WEAPON_ACTION_1);
            anim.SetMeleeWeaponAttackAnim();
        }
        // Check guard input
        else if (Input.GetKeyDown((KeyCode)Global.WEAPON_ACTION_2))
        {
            weaponholder.ProcessAction(Global.WEAPON_ACTION_2);
            anim.SetMeleeWeaponGuardAnim();
        }
        // Check dash input
        else if (Input.GetKeyDown((KeyCode)Global.WEAPON_ACTION_3))
        {
            if (!status.IsAbleToDash()) return;
            weaponholder.ProcessAction(Global.WEAPON_ACTION_3);
            anim.SetMeleeWeaponDashAnim();
        }

    }
}
