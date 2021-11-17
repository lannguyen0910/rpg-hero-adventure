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
        if (weaponholder.GetCurrentWeapon() != Global.MELEE_WEAPON) return;
        // Check if doing other action
        if (status.IsDelay()) return;

        // Check attack input
        if (Input.GetKeyDown((KeyCode)Global.WEAPON_ACTION_1))
        {
            weaponholder.ProcessAction(Global.WEAPON_ACTION_1);
            anim.SetMeleeWeaponAttackAnim(status.attackSpeed);
        }
        // Check dash input

        // Check guard input
    }
}
