using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject buildEffect;
    public GameObject sellEffect;
    public NodeUI nodeUI;

    private TurretBluePrint turretToBuild;
    private Node selectedNode;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager!");
            return;
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStates.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
