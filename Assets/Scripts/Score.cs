using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerStats.score.ToString();
        highScoreText.text = PlayerStats.highScore.ToString();
    }
}
