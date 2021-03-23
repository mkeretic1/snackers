using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    void Update()
    {
        if (GameManager.startGame)
        {
            this.gameObject.SetActive(false);
        }
    }
}
