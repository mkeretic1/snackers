using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Abilities : MonoBehaviour
{
    public bool noActiveAbility = true;

    public bool freezeAbility;
    public bool destroyEnemiesAbility;
    public bool resetSpeedAbility;
    public bool invulnerabilityAbility;
    public bool extraCoinsAbility;

    public GameObject freezeEnemiesAbilityEffect;
    public GameObject destroyEnemiesAbilityEffect;
    public GameObject resetSpeedAbilityEffect;
    public GameObject invulnerableAbilityEffect;
    public GameObject rollSuccessEffect;

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
            freezeEnemies(player);
            
        }else if (destroyEnemiesAbility)
        {           
            destroyAllEnemies(player);
        }else if (resetSpeedAbility)
        {
            resetSpeed(player);
        }else if (invulnerabilityAbility)
        {
            castInvulnerability();
        }
    }

    private void freezeEnemies(GameObject player)
    {
        AudioManager.instance.play("Freeze");

        GameObject effect = Instantiate(freezeEnemiesAbilityEffect, player.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in gameObjects)
        {
            if (go.tag.Equals("Enemy"))
            {
                go.GetComponent<EnemyMovement>().freeze();
            }
        }
    }

    private void destroyAllEnemies(GameObject player)
    {
        AudioManager.instance.play("Explosion");

        GameObject effect = Instantiate(destroyEnemiesAbilityEffect, player.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject go in gameObjects)
        {
            if (go.tag.Equals("Enemy"))
            {
                go.GetComponent<Enemy>().die();
            }
        }
    }

    private void resetSpeed(GameObject player)
    {
        AudioManager.instance.play("Slowdown");

        GameObject effect = Instantiate(resetSpeedAbilityEffect, player.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

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

        AudioManager.instance.play("Invulnerable");

        GameObject effect = Instantiate(invulnerableAbilityEffect, player.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

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
                GameObject player = GameObject.FindGameObjectWithTag("Player");

                player.GetComponent<Animator>().SetTrigger("RollSuccess");

                AudioManager.instance.play("RollSuccess");

                GameObject effect = Instantiate(rollSuccessEffect, player.transform.position, Quaternion.identity);
                Destroy(effect, 5f);


                PlayerStats.score += PlayerStats.coinValue;
            }
        }
    }
}
