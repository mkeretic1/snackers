using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver)
        {
            btn.interactable = false;
        }
    }

    public void pauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }
}
