using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    GameObject portal;
    [SerializeField]
    GameObject stageClearAnimation;

    bool stageEnd = false;

    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            portal.GetComponent<Portal>().SetPlayer(player);
            GameObject.Find("Main Camera").GetComponent<CameraController>().SetTarget(player);
            return;
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
            // Generate buff here
            if (stageClearAnimation != null) stageClearAnimation.SetActive(true);
            // Open portal
            portal.SetActive(true);
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
