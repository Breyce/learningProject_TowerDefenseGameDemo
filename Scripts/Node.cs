using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer render;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) { return; }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStates.Money < bluePrint.cost)
        {
            Debug.Log("No enough MONEY!");
            return;
        }

        PlayerStates.Money -= bluePrint.cost;

        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab, transform.position + Vector3.up * .5f, Quaternion.identity);

        turret = _turret;
        turretBluePrint = bluePrint;

        Destroy((GameObject)Instantiate(buildManager.buildEffect, transform.position + Vector3.up * .5f, Quaternion.identity), 5f);

        Debug.Log("Turret build! Money LEFT : " + PlayerStates.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStates.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("No enough MONEY!");
            return;
        }

        PlayerStates.Money -= turretBluePrint.upgradeCost;

        // ÒÆ³ý¾ÉÎäÆ÷
        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, transform.position + Vector3.up * .5f, Quaternion.identity);
        turret = _turret;


        Destroy(Instantiate(buildManager.buildEffect, transform.position + Vector3.up * .5f, Quaternion.identity), 5f);

        isUpgraded = true;

        Debug.Log("Turret UPGRADE");
    }

    public void SellTurret()
    {
        PlayerStates.Money += turretBluePrint.sellProfit;

        //Spawn a cool Effect
        Destroy(Instantiate(buildManager.sellEffect, transform.position + Vector3.up * .5f, Quaternion.identity), 5f);

        Destroy(turret);
        turretBluePrint = null;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        if (!buildManager.CanBuild) { return; }

        if (buildManager.HasMoney)
        {
            render.material.color = hoverColor;
        }
        else
        {
            render.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }
}
