using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemy1Prefab;
    public Transform enemy2Prefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    private float countdown = 5f;

    public TextMeshProUGUI waveCountdown;

    private int waveNumber = 1;

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
                SpawnEnemy(enemy1Prefab, spawnPoint);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 3)
        {
            for (int i = 1; i < 11; i++)
            {
                SpawnEnemy(enemy1Prefab, spawnPoint);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 4)
        {
            for (int i = 1; i < 6; i++)
            {
                SpawnEnemy(enemy2Prefab, spawnPoint);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (waveNumber == 5)
        {
            for (int i = 1; i < 11; i++)
            {
                SpawnEnemy(enemy2Prefab, spawnPoint);
                yield return new WaitForSeconds(0.5f);
            }
        }
        
    }

    public static void SpawnEnemy(Transform enemyPrefab, Transform spawnPoint)
    {
        Instantiate(enemyPrefab, spawnPoint.position, enemyPrefab.rotation);
    }
}
