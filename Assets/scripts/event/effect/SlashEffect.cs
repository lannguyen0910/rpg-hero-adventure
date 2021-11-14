using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : EventEffect
{
    float currentDelay = 0;

    float damage = 0f;
    float delay = 0f;

    PlayerStatus playerStatus = null;
    WeaponStatus weaponStatus = null;

    void Start()
    {
        eventCode = 2;
        base.Start();

        currentDelay = 0;
    }

    public override void process(GameObject source)
    {
        if (playerStatus == null || weaponStatus == null)
        {
            playerStatus = source.GetComponent<PlayerStatus>();
            weaponStatus = source.GetComponentInChildren<WeaponStatus>();

            damage = weaponStatus.damage;
            delay = playerStatus.attackSpeed + weaponStatus.bonusAttackSpeed;
        }

        currentDelay += Time.deltaTime;

        if (currentDelay >= delay * 15f / 40f)
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }

        if (currentDelay >= delay)
        {
            currentDelay = 0;
            Destroy(gameObject, 0);
        }
    }
}
