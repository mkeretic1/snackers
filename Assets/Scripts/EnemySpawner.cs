using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject player;

    public GameObject topSpawnArea;
    public GameObject bottomSpawnArea;

    public float spawnBuffer;
    private bool spawningStarted;

    private bool rotate;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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


    IEnumerator spawnEnemies()
    {
        while (!GameManager.gameOver)
        {
            Transform playerTransform = player.transform;
            Vector2 spawnPosition = generateSpawnPosition(playerTransform);

            GameObject EnemyGO = (GameObject) Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            if (rotate) EnemyGO.transform.Rotate(new Vector3(0, 0, 180), Space.World);
            yield return new WaitForSeconds(spawnBuffer);
        }
    }

    private Vector2 generateSpawnPosition(Transform playerTransform)
    {
        MeshCollider meshCollider = findFurthestSpawnArea(playerTransform);
        float x = Random.Range(meshCollider.bounds.min.x, meshCollider.bounds.max.x);
        float y = Random.Range(meshCollider.bounds.min.y, meshCollider.bounds.max.y);
        return new Vector2(x, y);
    }

    private MeshCollider findFurthestSpawnArea(Transform playerTransform)
    {
        float distanceTop = Vector3.Distance(topSpawnArea.transform.position, playerTransform.position);
        float distanceBottom = Vector3.Distance(bottomSpawnArea.transform.position, playerTransform.position);
        if(distanceTop > distanceBottom)
        {
            rotate = true;
            return topSpawnArea.GetComponent<MeshCollider>();
        }
        else
        {
            rotate = false;
            return bottomSpawnArea.GetComponent<MeshCollider>();
        }
    }
}
