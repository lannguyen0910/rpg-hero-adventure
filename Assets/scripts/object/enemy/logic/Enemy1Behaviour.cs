using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour
{
    public GameObject target;
    public GameObject slashArea;

    Rigidbody2D rigid;
    Enemy1Animation anim;
    EnemyStatus status;

    [SerializeField]
    float step = 3;
    bool chaseMode = false;
    int direction = 3;
    float stepLeft = 0;


    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Enemy1Animation>();
        status = gameObject.GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status.actionDelay > 0) return;
        
        if (status.health <= 0) Destroy(gameObject, 0);

        anim.setMoveAnim(direction);
    }

    void FixedUpdate()
    {
        if (status.actionDelay > 0)
        {
            status.actionDelay -= Time.deltaTime;
            if (status.actionDelay <= GlobalConstraints.EPS)
                anim.resetAnim();
            return;
        }

        if (target == null) return;

        if (chaseMode)
        {
            if (Math.Abs(transform.position.x - target.transform.position.x) > GlobalConstraints.OFFSET)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    rigid.velocity = new Vector2(status.moveSpeed, 0);
                    direction = 3;
                }
                else if (transform.position.x > target.transform.position.x)
                {
                    rigid.velocity = new Vector2(-status.moveSpeed, 0);
                    direction = 1;
                }
            }
            else if (Math.Abs(transform.position.y - target.transform.position.y) > GlobalConstraints.OFFSET)
            {
                if (transform.position.y < target.transform.position.y)
                {
                    rigid.velocity = new Vector2(0, status.moveSpeed);
                    direction = 2;
                }
                else if (transform.position.x > target.transform.position.x)
                {
                    rigid.velocity = new Vector2(0, -status.moveSpeed);
                    direction = 0;
                }
            }
        }
        else
        {
            if (GlobalConstraints.calDistance(transform.position, target.transform.position) <= status.detectDistance * status.detectDistance)
            {
                chaseMode = true;
                return;
            }

            if (stepLeft <= GlobalConstraints.EPS)
            {
                stepLeft = step;
                direction = (direction + 1) % 4;
                anim.resetAnim();
            }

            stepLeft -= Time.deltaTime;
            if (direction == 0)
                rigid.velocity = new Vector2(0, -status.moveSpeed);
            else if (direction == 1)
                rigid.velocity = new Vector2(-status.moveSpeed, 0);
            else if (direction == 2)
                rigid.velocity = new Vector2(0, status.moveSpeed);
            else if (direction == 3)
                rigid.velocity = new Vector2(status.moveSpeed, 0);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (status.actionDelay > 0) return;

        if (col.gameObject == target)
        {
            rigid.velocity = new Vector2(0, 0);
            status.actionDelay = 50f / 60f;
            anim.resetAnim();

            if (target.transform.position.x < transform.position.x - GlobalConstraints.OFFSET)
                direction = 1;
            else if (target.transform.position.x > transform.position.x + GlobalConstraints.OFFSET)
                direction = 3;
            else if (target.transform.position.y < transform.position.y - GlobalConstraints.OFFSET)
                direction = 0;
            else if (target.transform.position.y > transform.position.y + GlobalConstraints.OFFSET)
                direction = 2;

            anim.setAttackAnim(direction);
            GameObject slashAreaInstance = Instantiate(slashArea, transform.parent);
            slashAreaInstance.transform.parent = transform;

            slashAreaInstance.transform.localPosition = new Vector3(0, 0, 0);
            slashAreaInstance.transform.localScale = new Vector3(0.25f, 0.25f, 0);
            slashAreaInstance.transform.Rotate(0, 0, direction * -90);
            slashAreaInstance.GetComponent<Bullet>().source = gameObject;
        }
    }

}
