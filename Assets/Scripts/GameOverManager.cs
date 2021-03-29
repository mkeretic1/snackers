using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text score;
    public Text best;

    public void retry()
    {
        AudioManager.instance.play("MainTheme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        AudioManager.instance.play("MainTheme");
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        score.text = PlayerStats.score.ToString();
        best.text = PlayerStats.highScore.ToString();
    }
}
