using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : EventEffect
{
    float readyDelay = 0f;
    float slashDelay = 0f;
    float maxDelay = Global.INF;
    float delay = -Global.INF;

    Rigidbody2D rigid;

    new void Start()
    {
        eventCode = Global.SLASH_CODE;
        base.Start();

        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    public override void Process(GameObject source)
    {
        rigid.velocity = new Vector2(0.001f, 0.001f);
        delay += Time.deltaTime;

        // Turn on hitbox
        if (delay >= readyDelay)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
        // Turn off hitbox after sometime
        if (delay >= readyDelay + slashDelay)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        // Destroy if anim is over
        if (Global.IsGreaterEqual(delay, maxDelay))
        {
            Destroy(gameObject);
        }
    }

    public void SetDelay(float delay)
    {
        this.maxDelay = delay;
        this.delay = 0;
    }

    public void SetAnimDelay(float readyDelay, float slashDelay)
    {
        this.readyDelay = readyDelay;
        this.slashDelay = slashDelay;
    }
}
