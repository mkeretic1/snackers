using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public Text coinsText;

    void Update()
    {
        coinsText.text = PlayerStats.totalCoins.ToString();
    }
}
