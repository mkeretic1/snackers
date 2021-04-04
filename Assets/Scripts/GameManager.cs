using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool startGame;
    public static bool gameOver;

    public GameObject gameOverUI;
    public GameObject controlsUI;
    public GameObject abilityUI;


    private GameObject playerPrefab;

    private GameObject playerGO;

    public GameObject abilityBtn;
    public GameObject abilityInfo;
    private Abilities abilities;

    void Awake()
    {
        playerPrefab = PlayerSelect.selectedPlayerSkin;
    }

    void Start()
    {
        playerGO = Instantiate(playerPrefab, new Vector3(0,0,0), Quaternion.identity);
        startGame = false;
        gameOver = false;
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
}
