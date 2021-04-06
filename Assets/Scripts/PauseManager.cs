using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    public Button btn;

    public GameObject activateAbilityUI;
    public bool canEnable;

    // Start is called before the first frame update
    void Start()
    {
        canEnable = false;
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
        if (activateAbilityUI.activeSelf)
        {
            canEnable = true;
            activateAbilityUI.SetActive(false);
        }
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }

    public void resumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        if(canEnable) activateAbilityUI.SetActive(true);
    }
}
