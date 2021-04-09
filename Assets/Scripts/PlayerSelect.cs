using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    public PlayerPrefab[] playerPrefabs;
    [HideInInspector]
    public int selectedPlayerPrefabIndex;
    private GameObject player;

    public GameObject playBtnGO;
    public GameObject purchaseBtnGO;
    public GameObject purchaseTextGO;

    public static GameObject selectedPlayerSkin;

    public Text abilityDescription;
    public Text purchaseBtnText;
    public Text purchaseText;

    void Awake()
    {
        selectedPlayerPrefabIndex = PlayerPrefs.GetInt("Selected", 0);
        playerPrefabs[0].purchased = 1;
        for (int i = 1; i < playerPrefabs.Length; i++)
        {
            playerPrefabs[i].purchased = PlayerPrefs.GetInt("Char" + (i+1), 0);
        }
    }

    void Start()
    {
        instantiatePlayerAndDisableMovement();

    }

    public void leftButtonPressed()
    {
        selectedPlayerPrefabIndex--;
        if (selectedPlayerPrefabIndex == -1) selectedPlayerPrefabIndex = playerPrefabs.Length - 1;

        instantiatePlayerAndDisableMovement();

    }

    public void rightButtonPressed()
    {
        selectedPlayerPrefabIndex++;
        if (selectedPlayerPrefabIndex == playerPrefabs.Length) selectedPlayerPrefabIndex = 0;

        instantiatePlayerAndDisableMovement();
    }

    private void instantiatePlayerAndDisableMovement()
    {
        if (player != null) Destroy(player);
        player = (GameObject)Instantiate(playerPrefabs[selectedPlayerPrefabIndex].prefab, new Vector3(0, 0, 0), Quaternion.identity);
        if (player != null) {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Abilities>().enabled = false;
            abilityDescription.text = playerPrefabs[selectedPlayerPrefabIndex].abilityDescription;
        }

        if (playerPrefabs[selectedPlayerPrefabIndex].purchased == 0)
        {
            playBtnGO.SetActive(false);
            purchaseBtnText.text = playerPrefabs[selectedPlayerPrefabIndex].cost.ToString();
            purchaseBtnGO.SetActive(true);
        }
        else
        {
            playBtnGO.SetActive(true);
            purchaseBtnGO.SetActive(false);
        }
    }

    public void play()
    {
        PlayerPrefs.SetInt("Selected", selectedPlayerPrefabIndex);
        selectedPlayerSkin = playerPrefabs[selectedPlayerPrefabIndex].prefab;
        SceneManager.LoadScene("MainScene");
    }

    public void purchase()
    {
        if (PlayerStats.totalCoins < playerPrefabs[selectedPlayerPrefabIndex].cost) return;

        AudioManager.instance.play("Purchase");
        purchaseText.text = "-" + playerPrefabs[selectedPlayerPrefabIndex].cost;
        purchaseTextGO.GetComponent<Animator>().SetTrigger("Purchased");


        PlayerStats.playerPurchased(playerPrefabs[selectedPlayerPrefabIndex].cost);
        playerPrefabs[selectedPlayerPrefabIndex].purchased = 1;
   
        PlayerPrefs.SetInt("Char" + (selectedPlayerPrefabIndex + 1), playerPrefabs[selectedPlayerPrefabIndex].purchased);

        playBtnGO.SetActive(true);
        purchaseBtnGO.SetActive(false);
    }

}