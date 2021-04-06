using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnWaitMin = 2f;
    public float spawnWaitMax = 5f;

    public GameObject spawnArea;
    private MeshCollider meshCollider;

    private float x;
    private float y;
    private Vector2 spawnPosition;
    private Vector3 spawnRotation = new Vector3(0,0, 0);
    private bool spawningStarted;

    void Start()
    {
        meshCollider = spawnArea.GetComponent<MeshCollider>();
        spawningStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawningStarted) return;

        if (GameManager.startGame)
        {
            StartCoroutine("spawnCoin");
            spawningStarted = true;
        }
    }

    IEnumerator spawnCoin()
    {
        while (!GameManager.gameOver)
        {
            x = Random.Range(meshCollider.bounds.min.x, meshCollider.bounds.max.x);
            y = Random.Range(meshCollider.bounds.min.y, meshCollider.bounds.max.y);
            spawnPosition = new Vector2(x, y);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(spawnWaitMin, spawnWaitMax));
        }
        
    }
}
