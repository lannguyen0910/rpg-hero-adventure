using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];

    SpriteRenderer spriteRenderer;

    int[] spriteForAnimation1 = new int[5] { 1, 1, 1, 1, 1 };
    int[] spriteForAnimation2 = new int[5] { 0, 1, 2, 1, 0 };
    int direction = 0;

    float meleeAttackAnimDelay = -0.9f;
    float magicCastAnimDelay = -0.7f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        // Turn off sprite when action is finished
        if (meleeAttackAnimDelay < Global.EPS && magicCastAnimDelay < Global.EPS)
        {
            spriteRenderer.enabled = false;
            return;
        }

        // Melee attack has 2 phase
        if (meleeAttackAnimDelay <= 0.42f)
        {
            spriteRenderer.sprite = sprites[spriteForAnimation2[direction]];
            spriteRenderer.sortingOrder = 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (meleeAttackAnimDelay > Global.EPS)
        {
            meleeAttackAnimDelay -= Time.deltaTime;
        }
        if (magicCastAnimDelay > Global.EPS)
        {
            magicCastAnimDelay -= Time.deltaTime;
        }
    }

    public void SetDirection(int direction)
    {
        this.direction = direction;
    }

    public void SetWeaponAttackAnim()
    {
        meleeAttackAnimDelay = 0.67f;

        spriteRenderer.sprite = sprites[spriteForAnimation1[direction]];
        spriteRenderer.sortingOrder = 3;
        spriteRenderer.enabled = true;
    }

    public void SetWeaponChargeAnim()
    {
        magicCastAnimDelay = 1000000f;
        meleeAttackAnimDelay = 1000000f;

        spriteRenderer.sprite = sprites[spriteForAnimation1[direction]];
        spriteRenderer.sortingOrder = 3;
        spriteRenderer.enabled = true;
    }

    public void SetWeaponCastAnim(bool castFlag)
    {
        if (castFlag)
        {
            magicCastAnimDelay = 0.33f;
            meleeAttackAnimDelay = 0f;
        }
        else
        {
            magicCastAnimDelay = 0f;
            meleeAttackAnimDelay = 0f;
            spriteRenderer.enabled = false;
        }

        spriteRenderer.sprite = sprites[spriteForAnimation2[direction]];
        spriteRenderer.sortingOrder = 1;
    }
}
