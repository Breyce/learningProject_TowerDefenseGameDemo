using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int cost;
    public int upgradeCost;
    public int sellProfit;

    public int GetUpgradeSellProfit()
    {
        return sellProfit * 2;
    }
}
