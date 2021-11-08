using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackController : MonoBehaviour
{
    WeaponHolder weaponholder;

    // Start is called before the first frame update
    void Start()
    {
        weaponholder = gameObject.GetComponent<WeaponHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            weaponholder.processCommand((int)KeyCode.C);
        }
    }
}
