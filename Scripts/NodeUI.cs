using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellProfit;
    public Button upgradeButton;

    private Node target;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.transform.position + Vector3.up * .5f;

        if (!target.isUpgraded)
        {
            upgradeCost.text = "UPGRADE\n" + "¥" + target.turretBluePrint.upgradeCost;
            sellProfit.text = "SELL\n" + "¥" + target.turretBluePrint.sellProfit;
            upgradeButton.interactable = true;
        }
        else
        {
            sellProfit.text = "SELL\n" + "¥" + target.turretBluePrint.GetUpgradeSellProfit();
            upgradeCost.text = "UPGRADE\n DONE";
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
