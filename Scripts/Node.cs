using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    [Header("Optional")]
    public GameObject turret;

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
        if (!buildManager.CanBuild) { return; }

        if(turret != null)
        {
            Debug.Log("Cannnot be placed");
            return;
        }

        buildManager.BuildTurretOn(this);
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
