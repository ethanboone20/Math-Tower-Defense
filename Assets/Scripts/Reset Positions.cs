using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositions : MonoBehaviour
{
    public GameObject[] enemies;

    void Awake()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            EnemyMovement newEnemy = enemies[i].GetComponent<EnemyMovement>();
            newEnemy.distanceTravelled = 0;
        }
    }
}
