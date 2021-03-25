using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGameOver : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }
}
