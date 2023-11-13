using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TowerSpots : MonoBehaviour
{
    public static TowerSpots instance;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject tower;

    private Renderer rend;
    private Color startColor;

    public TMP_InputField userInputField;

    BuildManager buildManager;
    Question question;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        question = Question.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (tower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        question.currentTowerSpot = this;
        
        if (PlayerStats.money >= buildManager.towerToBuild.cost)
        {
            if (question.questionType == "Addition")
            {
                question.AdditionQuestion();
            }
            if (question.questionType == "Subtraction")
            {
                    question.SubtractionQuestion();
            }
            if (question.questionType == "Multiplication")
            {
                question.MultiplicationQuestion();
                }
            if (question.questionType == "Division")
            {
                question.DivisionQuestion();
            }
        }
        else
        {
            Debug.Log("Not enough money to build that!");
        }
        
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void BuildTower()
    {
        buildManager.BuildTowerOn(this);
    }
}
