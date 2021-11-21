using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private GameObject portal;

    bool stageEnd = false;

    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            portal.GetComponent<Portal>().SetPlayer(player);
            GameObject.Find("Main Camera").GetComponent<CameraController>().SetTarget(player);
        }

        if (stageEnd) return;

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
            // Open portal
            portal.SetActive(true);

            // Generate buff here
            BuffManager.GetRandomBuffs()[0].Process(player);

            stageEnd = true;
        }
    }

    public Vector3 GetNearestEnemyPosition()
    {
        Vector3 position = player.transform.position;
        Vector3 result = transform.position;
        float minDistance = Global.INF;

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;
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
