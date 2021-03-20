using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    public GameObject coinGO;
    public GameObject spawnArea;
    private MeshCollider meshCollider;

    private float x;
    private float y;
    private Vector2 spawnPosition;
    private Vector3 spawnRotation = new Vector3(0, 0, 0);
    private bool spawningStarted;

    public static BuffSpawner instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        coinGO.SetActive(false);
        meshCollider = spawnArea.GetComponent<MeshCollider>();
        spawningStarted = false;
    }

    void Update()
    {
        if (spawningStarted) return;
        if (!GameManager.startGame) return;

        startBuffControl();
    }

    private void startBuffControl()
    {
        coinGO.SetActive(true);
        spawningStarted = true;
        repositionBuff();
    }

    public void repositionBuff()
    {
        x = Random.Range(meshCollider.bounds.min.x, meshCollider.bounds.max.x);
        y = Random.Range(meshCollider.bounds.min.y, meshCollider.bounds.max.y);
        this.coinGO.transform.position = new Vector2(x, y);
    }
}
