using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public GameObject[] stagePortal;

    public GameObject[] enemies;
    public int[] enemyPerStage;

    [SerializeField]
    int currentStage = 0;
    int maxStage;

    void Awake()
    {
        maxStage = stagePortal.Length;

        for (int i = 1; i < maxStage; i++) enemyPerStage[i] += enemyPerStage[i - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStage == maxStage) return;

        int start = (currentStage > 0 ? enemyPerStage[currentStage - 1] : 0);
        int end = enemyPerStage[currentStage];
        int count = 0;

        for (int i = start; i < end; i++)
            if (!(enemies[i] == null))
                count++;

        if (count == 0)
        {
            stagePortal[currentStage].SetActive(true);
            currentStage++;
        }
    }

    public List<GameObject> getStageEnemies(int stage)
    {
        if (currentStage == maxStage) return null;
        if (stage != currentStage) return null;

        List<GameObject> stageEnemies = new List<GameObject>();

        int start = (stage > 0 ? enemyPerStage[stage - 1] : 0);
        int end = enemyPerStage[stage];

        for (int i = start; i < end; i++)
            stageEnemies.Add(enemies[i]);

        return stageEnemies;
    }
}
