using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    public GameObject gameOverUI;
    
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayGameOverSound();
        }
        else
        {
            Debug.LogWarning("No AudioController Instance found!");
        }

        gameEnded = true;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
}
