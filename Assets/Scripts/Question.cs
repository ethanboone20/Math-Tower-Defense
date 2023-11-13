using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question : MonoBehaviour
{

    public static Question instance;

    public GameObject questionUI;
    public TextMeshProUGUI numberText;
    public TMP_InputField userInputField;
    public TextMeshProUGUI resultText;

    public string questionType;

    private int num1;
    private int num2;
    private int sum;
    private int diff;
    private int prod;
    private int quo;

    public bool isCorrect = false;

    public TowerSpots currentTowerSpot;

    BuildManager buildManager;
    TowerSpots towerSpots;


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Question in scene!");
            return;
        }
        instance = this;
    }

    void Start()
    {
        buildManager = BuildManager.instance;
        towerSpots = TowerSpots.instance;
    }

    public void AdditionQuestion()
    {
        Time.timeScale = 0;

        num1 = Random.Range(1, 11); // Change the range as needed
        num2 = Random.Range(1, 11); // Change the range as needed

        numberText.text = num1 + " + " + num2 + " = ?";
        sum = num1 + num2;
        resultText.text = "";
        userInputField.text = "";

        questionUI.SetActive(true);

    }
    public void SubtractionQuestion()
    {
        Time.timeScale = 0;

        num1 = Random.Range(11, 21); // Change the range as needed
        num2 = Random.Range(1, 11); // Change the range as needed

        numberText.text = num1 + " - " + num2 + " = ?";
        diff = num1 - num2;
        resultText.text = "";
        userInputField.text = "";

        questionUI.SetActive(true);

    }
    public void MultiplicationQuestion()
    {
        Time.timeScale = 0;

        num1 = Random.Range(1, 11); // Change the range as needed
        num2 = Random.Range(1, 11); // Change the range as needed

        numberText.text = num1 + " * " + num2 + " = ?";
        prod = num1 * num2;
        resultText.text = "";
        userInputField.text = "";

        questionUI.SetActive(true);

    }
    public void DivisionQuestion()
    {
        Time.timeScale = 0;

        num1 = Random.Range(1, 11); // Change the range as needed
        num1 *= 10;
        int[] num2Choices = {1, 2, 5, 10};
        num2 = num2Choices[Random.Range(0, num2Choices.Length)];

        numberText.text = num1 + " / " + num2 + " = ?";
        quo = num1 / num2;
        resultText.text = "";
        userInputField.text = "";

        questionUI.SetActive(true);

    }

    void CheckAddition()
    {
        if (sum == int.Parse(userInputField.text))
        {
            isCorrect = true;
            resultText.text = "Correct!";
            
            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayCorrectAnswerSound(); //play audioClip for correct answer
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }
        }
        else
        {
            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayIncorrectAnswer(); //play audioClip for incorrect answer
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }

            resultText.text = "Incorrect!";
        }

        StartCoroutine(Wait());
        questionUI.SetActive(false);
        Time.timeScale = 1;
        PlaceTower();
    }
    void CheckSubtraction()
    {
        if (diff == int.Parse(userInputField.text))
        {
            isCorrect = true;
            resultText.text = "Correct!";

            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayCorrectAnswerSound(); //play audioClip for correct answer
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }
        }
        else
        {
            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayIncorrectAnswer(); //play audioClip for incorrect answer
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }

            resultText.text = "Incorrect!";
        }

        StartCoroutine(Wait());
        questionUI.SetActive(false);
        Time.timeScale = 1;
        PlaceTower();
    }
    void CheckMultiplication()
    {
        if (prod == int.Parse(userInputField.text))
        {
            isCorrect = true;
            resultText.text = "Correct!";

            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayCorrectAnswerSound(); //play audioClip for correct answer
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }
        }
        else
        {
            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayIncorrectAnswer(); //play audioClip for incorrect answer
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }

            resultText.text = "Incorrect!";
        }

        StartCoroutine(Wait());
        questionUI.SetActive(false);
        Time.timeScale = 1;
        PlaceTower();
    }
    void CheckDivision()
    {
        if (quo == int.Parse(userInputField.text))
        {
            isCorrect = true;
            resultText.text = "Correct!";

            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayCorrectAnswerSound(); //play audioClip for correct answer
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }
        }
        else
        {
            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayIncorrectAnswer(); //play audioClip for incorrect answer
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }

            resultText.text = "Incorrect!";
        }

        StartCoroutine(Wait());
        questionUI.SetActive(false);
        Time.timeScale = 1;
        PlaceTower();
    }

    public void SubmitButtonClicked()
    {
        if (questionType == "Addition")
        {
            CheckAddition();
        }
        if (questionType == "Subtraction")
        {
            CheckSubtraction();
        }
        if (questionType == "Multiplication")
        {
            CheckMultiplication();
        }
        if (questionType == "Division")
        {
            CheckDivision();
        }
    }

    void PlaceTower()
    {
        if (isCorrect == true)
        {
            currentTowerSpot.BuildTower();
        }
        else
        {
            PlayerStats.money -= buildManager.towerToBuild.cost;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }

}
