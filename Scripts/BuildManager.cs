using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject buildEffect;

    private TurretBluePrint turretToBuild;

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

    public void BuildTurretOn(Node node)
    {
        if(PlayerStates.Money < turretToBuild.cost) 
        {
            Debug.Log("No enough MONEY!");
            return; 
        }

        PlayerStates.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + Vector3.up * .5f, Quaternion.identity);
        node.turret = turret;

        Destroy(Instantiate(buildEffect, node.transform.position + Vector3.up * .5f, Quaternion.identity), 5f);

        Debug.Log("Turret build! Money LEFT : " + PlayerStates.Money);
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }
}
