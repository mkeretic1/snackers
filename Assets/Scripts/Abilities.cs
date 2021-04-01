using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public bool freezeAbility;
    public bool destroyEnemiesAbility;
    public bool resetSpeedAbility;
    public bool invulnerabilityAbility;
    public bool extraCoinsAbility;

    private bool casted;

    public Color invulnerableColor;

    void Start()
    {
        casted = false;
    }

    public void castAbility(GameObject player)
    {
        if (casted) return;
        casted = true;
    
        if (freezeAbility)
        {
            freezeEnemies();
            
        }else if (destroyEnemiesAbility)
        {           
            destroyAllEnemies();
        }else if (resetSpeedAbility)
        {
            resetSpeed();
        }else if (invulnerabilityAbility)
        {
            castInvulnerability();
        }
    }

    private void freezeEnemies()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in gameObjects)
        {
            if (go.tag.Equals("Enemy"))
            {
                go.GetComponent<EnemyMovement>().freeze();
            }
        }
    }

    private void destroyAllEnemies()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject go in gameObjects)
        {
            if (go.tag.Equals("Enemy"))
            {
                go.GetComponent<Enemy>().die();
            }
        }
    }

    private void resetSpeed()
    {
        PlayerStats.resetSpeed();
    }

    private void castInvulnerability()
    {
        StartCoroutine("invulnerability");
    }

    IEnumerator invulnerability()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            yield break;
        }

        PlayerStats.invulnerable = true;
        Renderer rend = player.GetComponent<Renderer>();

        Color startColor = rend.material.GetColor("_Color");
        rend.material.SetColor("_Color", invulnerableColor);

        yield return new WaitForSeconds(10f);

        PlayerStats.invulnerable = false;
        rend.material.SetColor("_Color", startColor);

    }

    public void rollForExtraCoins()
    {
        if (extraCoinsAbility)
        {
            int randomNumber = Random.Range(0, 100);

            if (randomNumber < 10)
            {
                PlayerStats.score += 10;
            }
        }
    }
}
