using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    public Text coinsText;

    void Update()
    {
        coinsText.text = PlayerStats.totalCoins.ToString();
    }
}
