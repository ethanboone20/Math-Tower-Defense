using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    public GameObject gameOverUI;
    public GameObject winGameUI;

    
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame(false);
        }
    }

    public void EndGame(bool playerWon)
    {
        
        gameEnded = true;
        Time.timeScale = 0;

        if (playerWon)
        {
            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayWinGameSound();
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }

            winGameUI.SetActive(true);
        }
        else
        {
            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayGameOverSound();
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found.");
            }

            gameOverUI.SetActive(true);
        }
    }
}
