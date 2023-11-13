using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemy1Prefab;
    public Transform enemy2Prefab;
    public Transform enemy3Prefab;
    public Transform enemy4Prefab;
    public Transform enemy5Prefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    private float countdown = 5f;

    public TextMeshProUGUI waveCountdown;

    private int waveNumber = 1;

    public GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdown.text = string.Format("Wave Countdown: {0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        PlayerStats.waves++;

        if (waveNumber == 2)
        {
            for (int i = 1; i < 6; i++)
            {
                SpawnEnemy(enemy1Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 3)
        {
            for (int i = 1; i < 11; i++)
            {
                SpawnEnemy(enemy1Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 4)
        {
            for (int i = 1; i < 6; i++)
            {
                SpawnEnemy(enemy2Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 5)
        {
            for (int i = 1; i < 11; i++)
            {
                SpawnEnemy(enemy2Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 6)
        {
            for (int i = 1; i < 6; i++)
            {
                SpawnEnemy(enemy3Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 7)
        {
            for (int i = 1; i < 11; i++)
            {
                SpawnEnemy(enemy3Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 8)
        {
            for (int i = 1; i < 6; i++)
            {
                SpawnEnemy(enemy4Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 9)
        {
            for (int i = 1; i < 11; i++)
            {
                SpawnEnemy(enemy4Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 10)
        {
            for (int i = 1; i < 6; i++)
            {
                SpawnEnemy(enemy5Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 11)
        {
            for (int i = 1; i < 11; i++)
            {
                SpawnEnemy(enemy5Prefab, spawnPoint.position);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 12)
        {
            gameManager.EndGame(true);
        }
        
        
    }

    public static void SpawnEnemy(Transform enemyPrefab, Vector3 spawnPoint)
    {
        Instantiate(enemyPrefab, spawnPoint, enemyPrefab.rotation);
    }
}
