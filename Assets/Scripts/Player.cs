using UnityEngine;

public class Player : MonoBehaviour
{
    BuffSpawner buffSpawner;
    private Animator animator;

    public GameObject coinCollectedFadeaway;
    public GameObject buffCollectedFadeaway;

    public GameObject deathEffect;
    public GameObject buffCollectedEffect;

    private Abilities playerAbility;


    void Start()
    {
        buffSpawner = BuffSpawner.instance;
        animator = this.GetComponent<Animator>();
        playerAbility = gameObject.GetComponent<Abilities>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.enemyLayer)
        {
            if (PlayerStats.invulnerable) return;
            die();
        }else if (collision.gameObject.layer == GameInfo.terrainLayer)
        {
            die();
        } else if (collision.gameObject.layer == GameInfo.coinLayer){
            collectCoin(collision);
            playerAbility.rollForExtraCoins();
        } else if (collision.gameObject.layer == GameInfo.buffLayer)
        {
            collectBuff(collision);
            
        }
    }

    private void die()
    {
        AudioManager.instance.stop("MainTheme");
        AudioManager.instance.play("GameOver");


        GameObject effect = Instantiate(deathEffect, this.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        PlayerStats.checkHighScore();
        Destroy(gameObject);
        GameManager.gameOver = true;
    }

    private void collectCoin(Collider2D collision)
    {
        AudioManager.instance.play("CoinCollected");

        GameObject fadeaway = Instantiate(coinCollectedFadeaway, collision.transform.position, Quaternion.identity);
        Destroy(fadeaway, 5f);

        GameObject effect = Instantiate(buffCollectedEffect, collision.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(collision.gameObject);
        PlayerStats.coinCollected();
        animator.SetTrigger("Collected");
    }

    private void collectBuff(Collider2D collision)
    {
        AudioManager.instance.play("BuffCollected");

        GameObject fadeaway = Instantiate(buffCollectedFadeaway, collision.transform.position, Quaternion.identity);
        Destroy(fadeaway, 5f);

        GameObject effect = Instantiate(buffCollectedEffect, collision.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        buffSpawner.repositionBuff();
        PlayerStats.buffCollected();
        animator.SetTrigger("Collected");
    }
}
