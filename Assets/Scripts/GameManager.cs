using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool startGame;
    public static bool gameOver;

    public GameObject gameOverUI;
    public GameObject controlsUI;

    void Start()
    {
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
