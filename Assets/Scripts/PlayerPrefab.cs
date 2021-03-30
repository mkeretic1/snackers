using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPrefab
{
    public GameObject prefab;
    public int cost;
    [HideInInspector]
    public int purchased;
}
