using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    BuffSpawner buffSpawner;
    private Animator animator;

    void Start()
    {
        buffSpawner = BuffSpawner.instance;
        animator = this.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.terrainLayer || collision.gameObject.layer == GameInfo.enemyLayer)
        {
            PlayerStats.checkHighScore();
            Destroy(gameObject);
            GameManager.gameOver = true;

        } else if (collision.gameObject.layer == GameInfo.coinLayer){
            Destroy(collision.gameObject);
            PlayerStats.coinCollected();
            animator.SetTrigger("Collected");
        } else if (collision.gameObject.layer == GameInfo.buffLayer)
        {
            buffSpawner.repositionBuff();
            PlayerStats.buffCollected();
            animator.SetTrigger("Collected");
        }
    }
}
