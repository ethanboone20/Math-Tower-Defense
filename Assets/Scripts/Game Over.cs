using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI wavesText;

    void OnEnable()
    {

        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayGameOverSound();
            AudioController.Instance.PauseGameSceneAudio();
        }
        else
        {
            Debug.LogWarning("No AudioController Instance found.");
        }

        wavesText.text = "Waves Survived: " + PlayerStats.waves.ToString();
    }
}
