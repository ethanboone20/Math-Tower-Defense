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
        AudioController.Instance.PauseGameSceneAudio();

        wavesText.text = "Waves Survived: " + PlayerStats.waves.ToString();
    }
}
