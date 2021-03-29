using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffTextValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = "x" + PlayerStats.coinValue.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
