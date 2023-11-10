using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyMovement : MonoBehaviour
{
    public Transform enemy;
    public Transform[] enemies;
    public PathCreator pathCreator;

    public int enemyNum;
    public float speed = 5;
    public int health = 100;
    public int value = 50;

    public GameObject deathEffect;

    public float distanceTravelled;
    public Transform newSpawnPosition;

    private float endPoint = 62f;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            if (AudioController.Instance != null)
            {
                AudioController.Instance.PlayEnemyDamageSound();
            }
            else
            {
                Debug.LogWarning("No AudioController Instance found!");
            }
        }
    }

    void Die()
    {
        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayEnemyDefeatSound();
        }
        else
        {
            Debug.LogWarning("No AudioController Instance found!");
        }

        if (enemyNum == 1)
        {
            GameObject effect1 = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect1, 5f);

            PlayerStats.money += value;

            Destroy(gameObject);
        }
        if (enemyNum == 2)
        {
            GameObject effect2 = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(effect2, 5f);

            PlayerStats.money += value;

            newSpawnPosition = transform;
            Debug.Log("New Spawn Position: " + newSpawnPosition);

            WaveSpawner.SpawnEnemy(enemies[0], newSpawnPosition);

            Destroy(gameObject);

        }

    }

    void Update()
    {
        if (pathCreator != null)
        {
            if (distanceTravelled >= endPoint)
            {
                EndPath();
                return;
            }
            else
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            }
        }
    }

    void EndPath()
    {
        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayReachedEOPSound();
        }
        else
        {
            Debug.LogWarning("No AudioController Instance found.");
        }
        
        PlayerStats.lives--;
        Destroy(enemy);
    }

}
