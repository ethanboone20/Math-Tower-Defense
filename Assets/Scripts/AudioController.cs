using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; } //Singleton instance

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private AudioSource audioSource; //referenced for all music audio clips

    public Slider musicVolumeSlider; //Volume slider for music 
    public Slider sfxVolumeSlider; //volume slider for sfx

    public AudioClip levelSelectAudioClip; //levelSelect music
    private AudioClip mainMenuAudioClip; //mainMenu music 

    public AudioClip[] gameSceneAudioClips; //array of audio clips to play while game is running
    private int currentClipIndex = 0; 

    public AudioClip buttonPressSound; //sound effect to play when a button is pressed
    public AudioClip enemyDamageSound; //sound effect to play when enemy gameObject takes damage
    public AudioClip enemyDefeatSound; //sound effect to play when enemy gameObject is destroyed (1 --> 0)
    public AudioClip placeTowerSound; //sound effect to play when a tower is placed
    public AudioClip towerFireSound; //sound effect to play when a tower fires at an enemy
    public AudioClip gameOverSound; //sound effect to play when the player loses the game
    public AudioClip winGameSound; //sound effect to play when the player completes all the waves
    public AudioClip countDownEffect; //sound effect to play when the player is running out of time to answer a question
    public AudioClip incorrectAnswer; //sound effect to play when a player answers a question incorrectly 
    public AudioClip correctAnswer; //sound effect to play when a player answers a question correctly 
    public AudioClip reachedEOP; //sound effect to play when an enemy reaches the end of the path (player loses a life)

    private AudioSource sfxSource; //source for playing sound effects 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        //Identify current scene
        string sceneName = SceneManager.GetActiveScene().name;

        //if in the game scene, set the audioSource to the first clip in the gameScene array
        if (sceneName == "Grassy Plains" && gameSceneAudioClips != null && gameSceneAudioClips.Length > 0)
        {
            audioSource.clip = gameSceneAudioClips[0];
            audioSource.loop = false; // do not loop individual clips since the array will be manually looped through 
            StartGameSceneLoop();
        }
        else
        {
            mainMenuAudioClip = audioSource.clip; //load music for main menu
            audioSource.loop = true; //set audio to loop
            PlayMusic();
        }
        
        //Initialize volume sliders
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = audioSource.volume;
            musicVolumeSlider.onValueChanged.AddListener(SetVolume);
        }    

        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.value = audioSource.volume;
            sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        }
 
    }

    
    void PlayMusic()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    //controls music volume
    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    //controls SFX volume 
    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
        }
    }

    public void ChangeToLevelSelectAudioClip()
    {
        if (audioSource != null && levelSelectAudioClip != null)
        {
            audioSource.clip = levelSelectAudioClip;
            PlayMusic();
        }
    }

    public void ChangeToMainMenuAudioClip()
    {
        if (audioSource != null && mainMenuAudioClip != null)
        {
            audioSource.clip = mainMenuAudioClip;
            PlayMusic();
        }
    }

    public void StartGameSceneLoop()
    {
        if (gameSceneAudioClips.Length > 0)
        {
            StopAllCoroutines(); 
            StartCoroutine(LoopGameSceneAudio());
        }
    }

    private IEnumerator LoopGameSceneAudio()
    {
        currentClipIndex = 0; 

        while (true)
        {
            audioSource.clip = gameSceneAudioClips[currentClipIndex];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            currentClipIndex = (currentClipIndex +1) % gameSceneAudioClips.Length;
        }

    }

    public void PlaySoundEffect(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.clip = clip; //assign the clip 
            sfxSource.Play(); //play assigned clip 
        }
    }

    public void PlayButtonPressSound() //sound effect to play when a button is clicked
    {
        PlaySoundEffect(buttonPressSound); 
    }

    public void PlayEnemyDamageSound() //sound effect to play when an enemy takes damage
    {
        PlaySoundEffect(enemyDamageSound);
    }

    public void PlayEnemyDefeatSound() //sound effect to play when an enemy is defeated
    {
        PlaySoundEffect(enemyDefeatSound);
    }

    public void PlayPlaceTowerSound() //sound effect to play when a tower is placed
    {
        PlaySoundEffect(placeTowerSound);
    }

    public void PlayTowerFireSound() //sound effect to play when a tower shoots
    {
        PlaySoundEffect(towerFireSound);
    }

    public void PlayGameOverSound() //sound effect to play when a player loses the game
    {
        PlaySoundEffect(gameOverSound);
    }

    public void PlayCorrectAnswerSound() //sound effect to play when a player answers a question correctly 
    {
        PlaySoundEffect(correctAnswer);
    }
     
    public void PlayIncorrectAnswer() //sound effect to play when a player answers a question incorrectly
    {
        PlaySoundEffect(incorrectAnswer);
    }

    /**
    public void PlayCountDownEffect() //sound effect to play when a player is running out of time to answer a question
    {
        PlaySoundEffect(countDownEffect);
    }
    **/

    public void PlayReachedEOPSound() //sound effect to play when the player loses a life (enemy unit reached end of path)
    {
        PlaySoundEffect(reachedEOP);
    }

    public void PlayWinGameSound() //sound effect to play when the player wins the game (all waves cleared)
    {
        PlaySoundEffect(winGameSound);
    }
    
    public void PauseGameSceneAudio() //method to pause the audio 
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }  

}
