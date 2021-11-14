using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
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
        if (weaponholder.getCurrentWeapon() != 0) return;
        if (status.actionDelay > 0) return;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            weaponholder.processCommand((int)KeyCode.Z);
            anim.setMeleeWeaponAnim(2, status.actionDelay);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            weaponholder.processCommand((int)KeyCode.X);
            anim.setMeleeWeaponAnim(1, status.actionDelay);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            weaponholder.processCommand((int)KeyCode.C);
            anim.setMeleeWeaponAnim(0, status.actionDelay);
        }

    }
}
