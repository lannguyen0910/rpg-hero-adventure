using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    GameObject hitbox;

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
        
    }

    void FixedUpdate()
    {
        // No target then do nothing
        if (target == null) return;

        // Perform attack
        if (Global.CalculateManhattanDistance(transform.position, target.transform.position) < status.attackRange)
        {

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
            }
            else // (transform.position.x > destination.x)
            {
                float step = Mathf.Min(transform.position.x - destination.x, status.moveSpeed);
                transform.position = new Vector3(transform.position.x - step, transform.position.y, 0);
            }
        }
        else if (!Global.IsEqual(transform.position.y, destination.y))
        {
            if (transform.position.y < destination.y)
            {
                float step = Mathf.Min(destination.y - transform.position.y, status.moveSpeed);
                transform.position = new Vector3(transform.position.x, transform.position.y + step, 0);
            }
            else // (transform.position.x > destination.x)
            {
                float step = Mathf.Min(transform.position.y - destination.y, status.moveSpeed);
                transform.position = new Vector3(transform.position.x, transform.position.y - step, 0);
            }
        }

    }

    
}
