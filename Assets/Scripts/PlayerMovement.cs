using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float rotationAmountPerFrame;
    //private Abilities playerAbility;

    void Start()
    {
        //playerAbility = gameObject.GetComponent<Abilities>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (!GameManager.startGame) GameManager.startGame = true;

            Touch touch = Input.GetTouch(0);

            //if(touch.tapCount == 2)
            //{
            //    playerAbility.castAbility(gameObject);
            //    //return;
            //}

            if (IsPointerOverUI(touch.fingerId)) return;


            if (touch.position.x < Screen.width / 2)
            {
                transform.Rotate(0, 0, Time.deltaTime * rotationAmountPerFrame, Space.World);
            }
            else
            {
                transform.Rotate(0, 0, Time.deltaTime * -rotationAmountPerFrame, Space.World);
            }

        }
    }

    void FixedUpdate()
    {
        if (!GameManager.startGame) return;

        transform.Translate(Vector2.up * Time.fixedDeltaTime * PlayerStats.speed);
    }

    private bool IsPointerOverUI(int fingerId)
    {
        EventSystem eventSystem = EventSystem.current;
        return (eventSystem.IsPointerOverGameObject(fingerId)
            && eventSystem.currentSelectedGameObject != null);
    }
}
