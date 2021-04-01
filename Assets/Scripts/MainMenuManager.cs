using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    public Text coinsText;

    public GameObject soundOnBtn;
    public GameObject soundOffBtn;
    private int sound;

    void Awake()
    {
        sound = PlayerPrefs.GetInt("Sound", 1);
    }

    void Start()
    {
        if(sound == 1)
        {
            soundOn();
        }
        else
        {
            soundOff();
        }
    }

    void Update()
    {
        coinsText.text = PlayerStats.totalCoins.ToString();
    }

    public void soundOff()
    {
        soundOffBtn.SetActive(false);
        soundOnBtn.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 0);
    }

    public void soundOn()
    {
        soundOffBtn.SetActive(true);
        soundOnBtn.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }
}
