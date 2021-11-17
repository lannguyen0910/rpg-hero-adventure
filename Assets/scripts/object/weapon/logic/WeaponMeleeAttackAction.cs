using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMeleeAttackAction : WeaponAction
{
    [SerializeField]
    private GameObject hitboxObject;

    PlayerStatus playerStatus;
    WeaponStatus weaponStatus;
    WeaponAnimation anim;

    new void Start()
    {
        // Auto add to action dictionary
        code = Global.WEAPON_ACTION_1;
        base.Start();

        anim = gameObject.GetComponent<WeaponAnimation>();
        weaponStatus = gameObject.GetComponent<WeaponStatus>();
        playerStatus = gameObject.transform.parent.transform.parent.gameObject.GetComponent<PlayerStatus>();
    }

    public override void Process()
    {
        int direction = playerStatus.direction;
        // Adjust direction
        Global.AdjustDirection(ref direction, Global.PLAYER_DIRECTION_BREAKPOINT);

        // Create new hitbox
        GameObject hitbox = Instantiate(hitboxObject, transform.parent);

        // Add hitbox to player
        hitbox.transform.parent = gameObject.transform.parent.parent;

        // Rotate hitbox to right direction
        hitbox.transform.localPosition = new Vector3(0, 0, 0);
        hitbox.transform.localScale = new Vector3(0.35f, 0.35f, 0);
        hitbox.transform.Rotate(0, 0, direction  * -45);

        // Add hitbox's source
        hitbox.GetComponent<Bullet>().source = gameObject.transform.parent.parent.gameObject;

        playerStatus.SetDelay(playerStatus.attackSpeed);
        anim.setWeaponAttackAnim(direction);

    }
}
