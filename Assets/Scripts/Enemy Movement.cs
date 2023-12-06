using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement instance;

    public GameObject enemy;
    public GameObject[] enemies;
    public PathCreator pathCreator;

    public int enemyNum;
    public float startSpeed = 5f;
    [HideInInspector]
    public float speed;
    public int health = 100;
    public int value = 50;

    public GameObject deathEffect;

    public float distanceTravelled;
    public Vector3 newSpawnPosition;

    private float endPoint = 62f;

    public EnemyMovement newEnemy;

    Tower tower;

    void Start()
    {
        speed = startSpeed;
        tower = Tower.instance;
    }

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

            //Sets the spawn position;
            newEnemy = enemies[0].GetComponent<EnemyMovement>();
            newEnemy.distanceTravelled = distanceTravelled;

            if (speed < 5)
            {
                newEnemy.speed = speed;
            }

            WaveSpawner.SpawnEnemy(enemies[0].transform, newSpawnPosition);

            Destroy(gameObject);
        }
        if (enemyNum == 3)
        {
            GameObject effect3 = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(effect3, 5f);

            PlayerStats.money += value;

            //Sets the spawn position;
            newEnemy = enemies[1].GetComponent<EnemyMovement>();
            newEnemy.distanceTravelled = distanceTravelled;

            if (speed < 5)
            {
                newEnemy.speed = speed;
            }

            WaveSpawner.SpawnEnemy(enemies[1].transform, newSpawnPosition);

            Destroy(gameObject);
        }
        if (enemyNum == 4)
        {
            GameObject effect4 = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(effect4, 5f);

            PlayerStats.money += value;

            //Sets the spawn position;
            newEnemy = enemies[2].GetComponent<EnemyMovement>();
            newEnemy.distanceTravelled = distanceTravelled;

            if (speed < 5)
            {
                newEnemy.speed = speed;
            }

            WaveSpawner.SpawnEnemy(enemies[2].transform, newSpawnPosition);

            Destroy(gameObject);
        }
        if (enemyNum == 5)
        {
            GameObject effect5 = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(effect5, 5f);

            PlayerStats.money += value;

            //Sets the spawn position;
            newEnemy = enemies[3].GetComponent<EnemyMovement>();
            newEnemy.distanceTravelled = distanceTravelled;

            if (speed < 5)
            {
                newEnemy.speed = speed;
            }

            WaveSpawner.SpawnEnemy(enemies[3].transform, newSpawnPosition);

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
