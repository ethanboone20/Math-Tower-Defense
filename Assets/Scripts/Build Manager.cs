using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject additionTowerPrefab;
    public GameObject subtractionTowerPrefab;
    public GameObject multiplicationTowerPrefab;
    public GameObject divisionTowerPrefab;

    public GameObject buildEffect;

    private TowerBlueprint towerToBuild;

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= towerToBuild.cost; } }

    public void BuildTowerOn(TowerSpots towerSpot)
    {
        if (PlayerStats.money < towerToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.money -= towerToBuild.cost;

        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayPlaceTowerSound();
        }
        else
        {
            Debug.LogWarning("No AudioController Instance found!");
        }

        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, towerSpot.GetBuildPosition(), Quaternion.identity);
        towerSpot.tower = tower;

        GameObject effect = (GameObject)Instantiate(buildEffect, towerSpot.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Tower built! Money left: " + PlayerStats.money);
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
    }

}
