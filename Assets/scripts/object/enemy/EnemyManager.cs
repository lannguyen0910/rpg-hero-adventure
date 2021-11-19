using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    public GameObject portal;

    bool done = false;

    void Start()
    {
        portal.GetComponent<Portal>().SetPlayer(player);
    }

    void Update()
    {
        if (done) return;

        int aliveEnemies = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                aliveEnemies++;
            }
        }
        if (aliveEnemies == 0)
        {
            portal.SetActive(true);
            // Generate buff here
        }
    }

    public Vector3 GetNearestEnemyPosition(Vector3 position)
    {
        Vector3 result = transform.position;
        float minDistance = Global.INF;

        foreach (GameObject enemy in enemies)
        {
            float distance = Global.CalculateDistance(enemy.transform.position, position);
            if (distance < minDistance)
            {
                minDistance = distance;
                result = enemy.transform.position;
            }
        }

        return result;
    }

}
