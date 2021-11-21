using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject meleeWeapon;
    [SerializeField]
    GameObject magicWeapon;
    [SerializeField]
    GameObject chargeAura;
    [SerializeField]
    GameObject shieldAura;

    Animator anim;
    PlayerStatus status;
    SpriteRenderer spriteRenderer;

    WeaponAnimation meleeWeaponAnim;
    WeaponAnimation magicWeaponAnim;
    Animator chargeAnim;
    ShieldAnimation shieldAnim;

    const int DIRECTION_COUNT = 8;
    const int DIRECTION_BREAKPOINT = 4;

    int[] stateSpeedX = new int[DIRECTION_COUNT] { 0, -1, -1, -1, 0, 1, 1, 1 };
    int[] stateSpeedY = new int[DIRECTION_COUNT] { -1, -1, 0, 1, 1, 1, 0, -1 };

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        status = gameObject.GetComponent<PlayerStatus>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        meleeWeaponAnim = meleeWeapon.GetComponent<WeaponAnimation>();
        magicWeaponAnim = magicWeapon.GetComponent<WeaponAnimation>();
        chargeAnim = chargeAura.GetComponent<Animator>();
        shieldAnim = shieldAura.GetComponent<ShieldAnimation>();
    }   

    public void SetMoveAnim(float speedX, float speedY)
    {
        // Normalize
        int sX = (speedX > 0 ? 1 : (speedX < 0 ? -1 : 0));
        int sY = (speedY > 0 ? 1 : (speedY < 0 ? -1 : 0));
        anim.SetInteger("speedX", sX);
        anim.SetInteger("speedY", sY);

        // Find the right direction
        if (sX != 0 || sY != 0)
        {
            for (int i = 0; i < DIRECTION_COUNT; i++)
            {
                if (stateSpeedX[i] == sX && stateSpeedY[i] == sY)
                {
                    status.direction = i;
                    break;
                }
            }

            int direction = status.direction;
            AdjustDirection(ref direction);
            anim.SetInteger("direction", direction);
        }
    }

    public void SetMeleeWeaponAttackAnim()
    {
        // Adjust direction
        int direction = status.direction;
        AdjustDirection(ref direction);

        anim.SetInteger("direction", direction);
        anim.SetInteger("weaponType", Global.MELEE_WEAPON);
        anim.SetInteger("actionType", Global.MELEE_ATTACK);

        meleeWeaponAnim.SetDirection(direction);
        meleeWeaponAnim.SetWeaponAttackAnim();
    }

    public void SetMeleeWeaponGuardAnim()
    {
        anim.SetInteger("weaponType", Global.MELEE_WEAPON);
        anim.SetInteger("actionType", Global.MELEE_GUARD);

        shieldAnim.SetShieldAnim();
    }

    public void SetMeleeWeaponDashAnim()
    {
        int direction = status.direction;
        AdjustDirection(ref direction);

        anim.SetInteger("direction", direction);
        anim.SetInteger("weaponType", Global.MELEE_WEAPON);
        anim.SetInteger("actionType", Global.MELEE_DASH);
    }

    public void SetMagicWeaponChargeAnim()
    {
        // Adjust direction
        int direction = status.direction;
        AdjustDirection(ref direction);

        chargeAnim.SetBool("isCharging", true);
        anim.SetInteger("direction", direction);
        anim.SetInteger("weaponType", Global.MAGIC_WEAPON);
        anim.SetInteger("actionType", Global.MAGIC_CHARGE);

        magicWeaponAnim.SetDirection(direction);
        magicWeaponAnim.SetWeaponChargeAnim();
    }

    public void SetMagicWeaponCastAnim()
    {
        chargeAnim.SetBool("isCharging", false);
        anim.SetInteger("actionType", status.actionType);

        if (status.actionType == Global.MAGIC_CAST)
        {
            magicWeaponAnim.SetWeaponCastAnim(true);
        }
        else
        {
            magicWeaponAnim.SetWeaponCastAnim(false);
        }
    }

    void AdjustDirection(ref int direction)
    {
        if (Global.AdjustDirection(ref direction, DIRECTION_BREAKPOINT))
        {
            transform.localScale = new Vector2(-1 * Math.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(Math.Abs(transform.localScale.x), transform.localScale.y);
        }
    }

}
