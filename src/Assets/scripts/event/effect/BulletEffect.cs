using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : EventEffect
{
    [SerializeField]
    Vector2 direction = new Vector2(1, 0);
    [SerializeField]
    float moveSpeed = 2f;

    Rigidbody2D rigid;

    new void Start()
    {
        eventCode = Global.BULLET_CODE;
        base.Start();

        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    public override void Process(GameObject source)
    {
        rigid.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction.normalized;
    }
}
