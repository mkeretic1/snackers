using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int score;
    public static int highScore;
    public static int coinValue;
    public static float speed;
    private static float speedIncrement_;
    private static int coinValueIncrement_;

    public int startScore;
    public int startCoinValue;
    public float startSpeed;

    public float speedIncrement = 1f;
    public int coinValueIncrement = 1;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        score = this.startScore;
        coinValue = this.startCoinValue;
        speed = this.startSpeed;
        speedIncrement_ = this.speedIncrement;
        coinValueIncrement_ = this.coinValueIncrement;
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
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
