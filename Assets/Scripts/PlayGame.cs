using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{


    public void LoadLevel()
    {
        SceneManager.LoadScene("Grassy Plains");
        Time.timeScale = 1; 

    }

    
}

