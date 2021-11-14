using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[3];

    int[] spriteForAnimation1 = new int[5] { 1, 1, 1, 1, 1 };
    int[] spriteForAnimation2 = new int[5] { 0, 1, 2, 1, 0 };

    SpriteRenderer spriteRenderer;
    float animationUpdate = -1;
    int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        if (animationUpdate <= 0)
        {
            spriteRenderer.enabled = false;
            return;
        }

        if (animationUpdate <= 25.0f / 60.0f)
            spriteRenderer.sprite = sprites[spriteForAnimation2[direction]];

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (animationUpdate < 0) return;

        animationUpdate -= Time.deltaTime;
    }

    public void setWeaponAttackAnim(int curDirection)
    {
        if (curDirection > 4)
            curDirection -= (curDirection - 4) * 2;

        direction = curDirection;
        animationUpdate = 40.0f / 60.0f;
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprites[spriteForAnimation1[direction]];
    }
}
