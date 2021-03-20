using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnPointsGO;
    public GameObject player;

    private Transform[] spawnPoints;

    public float spawnBuffer;
    private bool spawningStarted;

    void Awake()
    {
        getSpawnPoints();
    }

    
    void Start()
    {
        spawningStarted = false;
    }

    void Update()
    {
        if (spawningStarted) return;

        if (GameManager.startGame)
        {
            StartCoroutine("spawnEnemies");
            spawningStarted = true;
        }
    }

    private void getSpawnPoints()
    {
        spawnPoints = new Transform[spawnPointsGO.transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = spawnPointsGO.transform.GetChild(i); 
        }
    }

    IEnumerator spawnEnemies()
    {
        while (!GameManager.gameOver)
        {
            Transform playerTransform = player.transform;
            Transform furthestSpawnPoint = findFurthestSpawnPoint(playerTransform);

            Instantiate(enemyPrefab, furthestSpawnPoint.position, furthestSpawnPoint.rotation);
            yield return new WaitForSeconds(spawnBuffer);
        }
    }

    private Transform findFurthestSpawnPoint(Transform playerTransform)
    {
        float longestDistance = 0.0f;
        float distance = 0.0f;
        Transform farthestSpawnPoint = null;

        foreach (Transform sp in spawnPoints)
        {
            distance = Vector3.Distance(playerTransform.position, sp.position);

            if (distance > longestDistance)
            {
                longestDistance = distance;
                farthestSpawnPoint = sp;
            }
        };

        return farthestSpawnPoint;
    }
}
