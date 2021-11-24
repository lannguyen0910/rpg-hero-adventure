using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    GameObject hitboxPrototype;
    GameObject hitbox = null;

    Map map;
    EnemyStatus status;

    EnemyAnimation anim;

    int[] dx = new int[4] { 0, 1, 0, -1 };
    int[] dy = new int[4] { 1, 0, -1, 0 };

    // Just need to move to dest cell on the grid
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        status = gameObject.GetComponent<EnemyStatus>();
        anim = gameObject.GetComponent<EnemyAnimation>();
        map = GameObject.Find("Map").gameObject.GetComponent<Map>();

        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!status.IsDelay()) anim.SetMoveAnim(status.direction);
    }
    
    protected virtual void Attack()
    {
        Vector3 sourcePosition = transform.position;
        Vector3 targetPosition = target.transform.position;
        Vector2 lookVector = new Vector2(targetPosition.x - sourcePosition.x, targetPosition.y - sourcePosition.y);
        float angle = Global.CalculateAngleBetween(Global.VECTOR_UNIT, lookVector);
        if (lookVector.x > 0) angle = 360 - angle;
        // Set real direction
        int direction = Global.NormalizeDirection(angle, true);
        status.direction = direction;
        Global.AdjustDirection(ref direction, 2);

        // Create new hitbox
        hitbox = Instantiate(hitboxPrototype, transform.parent);
        hitbox.SetActive(true);
        // Add hitbox to player
        hitbox.transform.parent = gameObject.transform;
        hitbox.GetComponent<Hitbox>().SetSource(gameObject);
        // Rotate hitbox to right direction
        hitbox.transform.localPosition = new Vector3(0, 0, 0);
        hitbox.transform.localRotation = hitboxPrototype.transform.localRotation;
        hitbox.transform.Rotate(0, 0, direction * -90f);

        status.SetDelay(status.attackSpeed);
        anim.SetAttackAnim(status.direction);
    }

    protected virtual void AdjustHitbox()
    {
        if (hitbox != null)
        {
            ((DamageDealer)(hitbox.GetComponent<DealerManager>().GetDealer(Global.DAMAGE_CODE)))
                .SetDamage(status.damage);
            SlashEffect slashEffect = ((SlashEffect)(hitbox.GetComponent<EffectManager>().GetEffect(Global.SLASH_CODE)));
            slashEffect.SetDelay(status.attackSpeed);
            slashEffect.SetAnimDelay(status.readySpeed, status.slashSpeed);
            hitbox = null;
        }
    }


    void FixedUpdate()
    {
        AdjustHitbox();

        // No target then do nothing
        if (target == null) return;
        if (status.IsDelay()) return;

        // Perform attack
        if (Global.CalculateManhattanDistance(transform.position, target.transform.position) < status.attackRange)
        {
            Attack();
            return;
        }

        // If reach destination cell
        if (Global.IsEqual(destination, transform.position))
        {
            // If target is insight then follow
            if (Global.CalculateManhattanDistance(transform.position, target.transform.position) < status.detectRange)
            {
                Vector3 dst = map.FindPathTo(transform.name, transform.position, target.transform.position);
                if (Global.IsEqual(destination, dst))
                    destination = map.GenerateNewDestination(transform.position);
                else
                    destination = dst;
            }
            // Else random destination
            else
            {
                destination = map.GenerateNewDestination(transform.position);
            }
        }

        // Keep moving to destination
        if (!Global.IsEqual(transform.position.x, destination.x))
        {
            if (transform.position.x < destination.x)
            {
                float step = Mathf.Min(destination.x - transform.position.x, status.moveSpeed);
                transform.position = new Vector3(transform.position.x + step, transform.position.y, 0);
                status.direction = 3;
            }
            else // (transform.position.x > destination.x)
            {
                float step = Mathf.Min(transform.position.x - destination.x, status.moveSpeed);
                transform.position = new Vector3(transform.position.x - step, transform.position.y, 0);
                status.direction = 1;
            }
        }
        else if (!Global.IsEqual(transform.position.y, destination.y))
        {
            if (transform.position.y < destination.y)
            {
                float step = Mathf.Min(destination.y - transform.position.y, status.moveSpeed);
                transform.position = new Vector3(transform.position.x, transform.position.y + step, 0);
                status.direction = 2;
            }
            else // (transform.position.y > destination.y)
            {
                float step = Mathf.Min(transform.position.y - destination.y, status.moveSpeed);
                transform.position = new Vector3(transform.position.x, transform.position.y - step, 0);
                status.direction = 0;
            }
        }
        status.actionType = 0;

    }

    public void SetTarget(GameObject gameObject)
    {
        target = gameObject;
    }
    
}
