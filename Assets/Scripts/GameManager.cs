using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static bool startGame;
    public static bool gameOver;
    public static Text scoreToCoinsText;

    public GameObject gameOverUI;
    public GameObject controlsUI;
    public GameObject abilityUI;


    private GameObject playerPrefab;

    private GameObject playerGO;

    public GameObject abilityBtn;
    public GameObject abilityInfo;
    private Abilities abilities;

    public Text scoreToCoinsText_;

    void Awake()
    {
        playerPrefab = PlayerSelect.selectedPlayerSkin;
    }

    void Start()
    {
        playerGO = Instantiate(playerPrefab, new Vector3(0,0,0), Quaternion.identity);
        startGame = false;
        gameOver = false;
        scoreToCoinsText = scoreToCoinsText_;
        checkForActiveAbility();
    }

    private void Update()
    {
        if (!startGame) return;

        controlsUI.SetActive(false);
        abilityUI.SetActive(false);

        if (!gameOver) return;

        if (abilityBtn.activeSelf) abilityBtn.SetActive(false); 
        if (gameOverUI.activeSelf) return;

        gameOverUI.SetActive(true);

    }

    public void castAbility()
    {
        if(abilities != null)
        {
            abilities.castAbility(playerGO);
            abilityBtn.SetActive(false);
        }
    }

    private void checkForActiveAbility()
    {
        abilities = playerGO.GetComponent<Abilities>();
        if (abilities != null && abilities.noActiveAbility)
        {
            abilityBtn.SetActive(false);
            abilityInfo.SetActive(false);
        }
    }

    public static void scoreToCoins()
    {
        scoreToCoinsText.text = "+" + PlayerStats.score;
        scoreToCoinsText.gameObject.GetComponent<Animator>().SetTrigger("Purchased");
    }
}
