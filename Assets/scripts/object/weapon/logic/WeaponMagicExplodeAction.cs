using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMagicExplodeAction : WeaponAction
{
    [SerializeField]
    GameObject bulletPrototype;
    GameObject bullet;

    PlayerStatus playerStatus;
    WeaponStatus weaponStatus;
    WeaponAnimation anim;

    bool isCharging = false;
    float chargeTime = 0f;
    int damageMultiplier = 1;

    new void Start()
    {
        // Auto add to action dictionary
        code = Global.WEAPON_ACTION_2;
        base.Start();

        bullet = null;
        anim = gameObject.GetComponent<WeaponAnimation>();
        weaponStatus = gameObject.GetComponent<WeaponStatus>();
        playerStatus = gameObject.transform.parent.transform.parent.gameObject.GetComponent<PlayerStatus>();
        bulletPrototype = Instantiate(bulletPrototype);
        bulletPrototype.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isCharging)
        {
            chargeTime += Time.deltaTime;
        }
        if (bullet != null)
        {
            ((DamageDealer)(bullet.GetComponent<DealerManager>().GetDealer(Global.DAMAGE_CODE)))
                .SetDamage(weaponStatus.damage * damageMultiplier * 0.9f);
            bullet = null;
        }
    }

    public override void Process()
    {
        if (isCharging)
        {
            playerStatus.SetDelay(playerStatus.castDelay);
            playerStatus.actionType = Global.MAGIC_CAST;

            if (Global.IsGreaterEqual(chargeTime, playerStatus.chargeSpeed))
            {
                // Create a normal fireball
                GameObject source = gameObject.transform.parent.parent.gameObject;
                bullet = Instantiate(bulletPrototype, transform.parent);
                bullet.SetActive(true);
                bullet.GetComponent<Hitbox>().SetSource(source);
                bullet.transform.parent = null;
                bullet.transform.position = new Vector3(source.transform.position.x, source.transform.position.y, 0);
                bullet.transform.localScale = bulletPrototype.transform.localScale;
                bullet.transform.localRotation = bulletPrototype.transform.localRotation;
                damageMultiplier = 1;

                if (Global.IsGreaterEqual(chargeTime, playerStatus.chargeSpeed * 2 + playerStatus.chargeDelay))
                {
                    // Create a bigger fireball
                    bullet.transform.localScale = new Vector3(bullet.transform.localScale.x * 1.5f, bullet.transform.localScale.y * 1.5f, 0);
                    damageMultiplier = 2;
                }
            }
            else
            {
                playerStatus.SetDelay(0);
                playerStatus.actionType = -1;
            }
            isCharging = false;
        }
        else
        {
            chargeTime = 0;
            isCharging = true;
            playerStatus.SetDelay(1000000f);
        }
    }
}
