using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public bool isDestroyed = false;

    public Vector3 scaleVector;
    public EnemyMovement enemyMovement;

    BuffSpawner buffSpawner;

    private Animator animator;

    void Start()
    {
        buffSpawner = BuffSpawner.instance;
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.gameOver) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.terrainLayer)
        {
            Destroy(gameObject);

        } else if (collision.gameObject.layer == GameInfo.enemyLayer){
            mergeEnemies(collision.gameObject);

        } else if (collision.gameObject.layer == GameInfo.coinLayer){
            Destroy(collision.gameObject);
            animator.SetTrigger("Collected");
        }
        else if (collision.gameObject.layer == GameInfo.buffLayer){
            buffSpawner.repositionBuff();
            enemyMovement.buffCollected();
            animator.SetTrigger("Collected");
        }
    }

    private void mergeEnemies(GameObject collisionGO)
    {
        if (this.isDestroyed)
        {
            Destroy(gameObject);
        }
        else
        {
            EnemyMovement collisionEnemyMovement = collisionGO.GetComponent<EnemyMovement>();
            Enemy collisionEnemy = collisionGO.GetComponent<Enemy>();
            Vector3 collisionEnemyLocalScale = collisionGO.transform.localScale;

            float centerX = (this.transform.position.x + collisionGO.transform.position.x) / 2;
            float centerY = (this.transform.position.y + collisionGO.transform.position.y) / 2;

            if (collisionEnemy)
            {
                collisionEnemy.isDestroyed = true;
            }

            if(this.transform.localScale.x > collisionEnemyLocalScale.x)
            {
                this.transform.localScale += scaleVector;
            }
            else
            {
                this.transform.localScale = collisionEnemyLocalScale + scaleVector;
                enemyMovement.speed = collisionEnemyMovement.speed;
            }

            this.transform.position = new Vector3(centerX, centerY, this.transform.position.z);
        }
    }
}
