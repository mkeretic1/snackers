using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool startGame;
    public static bool gameOver;

    public GameObject gameOverUI;
    public GameObject controlsUI;

    private GameObject playerPrefab;

    void Awake()
    {
        playerPrefab = PlayerSelect.selectedPlayerSkin;
    }

    void Start()
    {
        Instantiate(playerPrefab, new Vector3(0,0,0), Quaternion.identity);
        startGame = false;
        gameOver = false;
    }

    private void Update()
    {
        if (!startGame) return;

        controlsUI.SetActive(false);

        if (!gameOver) return;

        if (gameOverUI.activeSelf) return;

        gameOverUI.SetActive(true);

    }
}
