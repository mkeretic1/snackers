using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool startGame;
    public static bool gameOver;

    void Start()
    {
        startGame = false;
        gameOver = false;
    }

}
