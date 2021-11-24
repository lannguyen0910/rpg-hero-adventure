using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMagicFireAction : WeaponAction
{
    [SerializeField]
    public GameObject bulletPrototype;
    GameObject bullet;

    PlayerStatus playerStatus;
    WeaponStatus weaponStatus;
    WeaponAnimation anim;

    bool isCharging = false;
    float chargeTime = 0f;
    int damageMultiplier = 1;

    Vector2 lookVector = Global.VECTOR_UNIT;

    new void Start()
    {
        // Auto add to action dictionary
        code = Global.WEAPON_ACTION_1;
        base.Start();

        bullet = null;
        anim = gameObject.GetComponent<WeaponAnimation>();
        weaponStatus = gameObject.GetComponent<WeaponStatus>();
        playerStatus = gameObject.transform.parent.transform.parent.gameObject.GetComponent<PlayerStatus>();

        string bulletName = bulletPrototype.name;
        Debug.Log("______HEY");
        bulletPrototype = Instantiate(bulletPrototype);
        bulletPrototype.name = bulletName;
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
                .SetDamage(weaponStatus.damage * damageMultiplier);
            ((BulletEffect)(bullet.GetComponent<EffectManager>().GetEffect(Global.BULLET_CODE)))
                .SetDirection(lookVector);
            bullet = null;
        }
    }

    public override void Process()
    {
        // Get enemy position and calculate direction
        GameObject source = gameObject.transform.parent.parent.gameObject;
        Vector3 sourcePosition = source.transform.position;
        Vector3 targetPosition = GameObject.Find("ObjectManager").GetComponent<ObjectManager>().GetNearestEnemyPosition();
        lookVector = new Vector2(targetPosition.x - sourcePosition.x, targetPosition.y - sourcePosition.y);
        // Calculate angle for rotation
        float angle = Global.CalculateAngleBetween(Global.VECTOR_UNIT, lookVector);
        if (lookVector.x > 0) angle = 360 - angle;
        // Set real direction
        playerStatus.direction = Global.NormalizeDirection(angle);

        if (isCharging)
        {
            playerStatus.SetDelay(playerStatus.castDelay);
            playerStatus.actionType = Global.MAGIC_CAST;
            
            if (Global.IsGreaterEqual(chargeTime, playerStatus.chargeSpeed))
            {
                // Create a normal fireball
                bullet = Instantiate(bulletPrototype, transform.parent);
                bullet.SetActive(true);
                // Setup position, rotation and scaling
                bullet.GetComponent<Hitbox>().SetSource(source);
                bullet.transform.parent = null;
                bullet.transform.position = new Vector3(source.transform.position.x, source.transform.position.y, 0);
                bullet.transform.localScale = bulletPrototype.transform.localScale;
                bullet.transform.localRotation = bulletPrototype.transform.localRotation;
                bullet.transform.Rotate(0, 0, -angle);
                damageMultiplier = 1;
                
                if (Global.IsGreaterEqual(chargeTime, playerStatus.chargeSpeed * 2 + playerStatus.chargeDelay))
                {
                    // Create a bigger fireball
                    bullet.transform.localScale *= 1.5f;
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
