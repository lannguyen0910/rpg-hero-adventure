using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponMeleeAttackAction : WeaponAction
{
    [SerializeField]
    GameObject hitboxPrototype;
    GameObject hitbox = null;

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
        
        // Clone prefab instance
        string hitboxName = hitboxPrototype.name;
        hitboxPrototype = Instantiate(hitboxPrototype);
        hitboxPrototype.name = hitboxName;
        hitboxPrototype.SetActive(false);
    }

    void FixedUpdate()
    {
        if (hitbox != null)
        {
            ((DamageDealer)(hitbox.GetComponent<DealerManager>().GetDealer(Global.DAMAGE_CODE)))
                .SetDamage(weaponStatus.damage);
            SlashEffect slashEffect = ((SlashEffect)(hitbox.GetComponent<EffectManager>().GetEffect(Global.SLASH_CODE)));
            slashEffect.SetDelay(playerStatus.attackSpeed);
            slashEffect.SetAnimDelay(playerStatus.readySpeed, playerStatus.slashSpeed);
            hitbox = null;
        }
    }

    public override void Process()
    {
        // Get enemy position and calculate direction
        GameObject source = gameObject.transform.parent.parent.gameObject;
        Vector3 sourcePosition = source.transform.position;
        Vector3 targetPosition = GameObject.Find("ObjectManager").GetComponent<ObjectManager>().GetNearestEnemyPosition();
        Vector2 lookVector = new Vector2(targetPosition.x - sourcePosition.x, targetPosition.y - sourcePosition.y);
        float angle = Global.CalculateAngleBetween(Global.VECTOR_UNIT, lookVector);
        if (lookVector.x > 0) angle = 360 - angle;
        // Set real direction
        int direction = Global.NormalizeDirection(angle);
        playerStatus.direction = direction;
        Global.AdjustDirection(ref direction, Global.PLAYER_DIRECTION_BREAKPOINT);

        // Create new hitbox
        hitbox = Instantiate(hitboxPrototype, transform.parent);
        hitbox.SetActive(true);
        // Add hitbox to player
        hitbox.transform.parent = gameObject.transform.parent.parent;
        hitbox.GetComponent<Hitbox>().SetSource(source);
        // Rotate hitbox to right direction
        hitbox.transform.localPosition = new Vector3(0, 0, 0);
        hitbox.transform.localRotation = hitboxPrototype.transform.localRotation;
        hitbox.transform.Rotate(0, 0, direction * -45f);

        playerStatus.SetDelay(playerStatus.attackSpeed);
    }
}
