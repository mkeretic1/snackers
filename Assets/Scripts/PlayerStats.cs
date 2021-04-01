using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int score;
    public static int highScore;
    public static int totalCoins;
    public static int coinValue;
    public static float speed;
    private static float startSpeed_;
    private static float speedIncrement_;
    private static int coinValueIncrement_;

    public int startScore;
    public int startCoinValue;
    public float startSpeed;

    public float speedIncrement = 1f;
    public int coinValueIncrement = 1;

    public static bool invulnerable;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        totalCoins = PlayerPrefs.GetInt("Coins", 0);
        score = this.startScore;
        coinValue = this.startCoinValue;
        speed = this.startSpeed;
        startSpeed_ = this.startSpeed;
        speedIncrement_ = this.speedIncrement;
        coinValueIncrement_ = this.coinValueIncrement;
        invulnerable = false;

    }

    public static void coinCollected()
    {
        score += coinValue;
    }

    public static void buffCollected()
    {
        coinValue += coinValueIncrement_;
        speed += speedIncrement_;
    }

    public static void checkHighScore()
    {
        totalCoins += score;
        PlayerPrefs.SetInt("Coins", totalCoins);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public static void playerPurchased(int cost)
    {
        totalCoins -= cost;
        PlayerPrefs.SetInt("Coins", totalCoins);
    }

    public static void resetSpeed()
    {
        speed = startSpeed_;
    }
}
