using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationAmountPerFrame;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (!GameManager.startGame) GameManager.startGame = true;

            Touch touch = Input.GetTouch(0);

            if(touch.position.x < Screen.width / 2)
            {
                transform.Rotate(0, 0, rotationAmountPerFrame, Space.World);
            }
            else
            {
                transform.Rotate(0, 0, -rotationAmountPerFrame, Space.World);
            }

        }
    }

    void FixedUpdate()
    {
        if (!GameManager.startGame) return;

        transform.Translate(Vector2.up * Time.fixedDeltaTime * PlayerStats.speed);
    }
}
