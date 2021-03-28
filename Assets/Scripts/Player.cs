using UnityEngine;

public class Player : MonoBehaviour
{
    BuffSpawner buffSpawner;
    private Animator animator;
    public GameObject coinCollectedFadeaway;

    void Start()
    {
        buffSpawner = BuffSpawner.instance;
        animator = this.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.terrainLayer || collision.gameObject.layer == GameInfo.enemyLayer)
        {
            Die(collision);
        } else if (collision.gameObject.layer == GameInfo.coinLayer){
            CollectCoin(collision);          
        } else if (collision.gameObject.layer == GameInfo.buffLayer)
        {
            CollectBuff(collision);
            
        }
    }

    private void Die(Collider2D collision)
    {
        PlayerStats.checkHighScore();
        Destroy(gameObject);
        GameManager.gameOver = true;
    }

    private void CollectCoin(Collider2D collision)
    {
        GameObject effect = Instantiate(coinCollectedFadeaway, collision.transform.position, collision.transform.rotation);
        effect.transform.position = collision.transform.position;
        Destroy(effect, 5f);

        Destroy(collision.gameObject);
        PlayerStats.coinCollected();
        animator.SetTrigger("Collected");
    }

    private void CollectBuff(Collider2D collision)
    {
        buffSpawner.repositionBuff();
        PlayerStats.buffCollected();
        animator.SetTrigger("Collected");
    }
}
