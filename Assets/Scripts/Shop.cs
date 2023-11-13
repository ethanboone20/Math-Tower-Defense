using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TowerBlueprint additionTower;
    public TowerBlueprint subtractionTower;
    public TowerBlueprint multiplicationTower;
    public TowerBlueprint divisionTower;

    BuildManager buildManager;
    Question question;

    void Start()
    {
        buildManager = BuildManager.instance;
        question = Question.instance;
    }
    
    public void SelectAdditionTower()
    {
        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayButtonPressSound();
        }
        else
        {
            Debug.LogWarning("No AudioController Instance found!");
        }

        Debug.Log("Addition Tower Selected!");
        buildManager.SelectTowerToBuild(additionTower);
        question.questionType = "Addition";
    }

    public void SelectSubtractionTower()
    {
        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayButtonPressSound();
        }
        else
        {
            Debug.LogWarning("No AudioController Instance found!");
        }

        Debug.Log("Subtraction Tower Selected!");
        buildManager.SelectTowerToBuild(subtractionTower);
        question.questionType = "Subtraction";
    }

    public void SelectMultiplicationTower()
    {
        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayButtonPressSound();
        }
        else
        {
            Debug.LogWarning("No AudioController Instance found!");
        }

        Debug.Log("Multiplication Tower Selected!");
        buildManager.SelectTowerToBuild(multiplicationTower);
        question.questionType = "Multiplication";
    }

    public void SelectDivisionTower()
    {
        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayButtonPressSound();
        }
        else
        {
            Debug.LogWarning("No AudioController Instance found!");
        }

        Debug.Log("Division Tower Selected!");
        buildManager.SelectTowerToBuild(divisionTower);
        question.questionType = "Division";
    }

}
