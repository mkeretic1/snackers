using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        this.transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }
}
