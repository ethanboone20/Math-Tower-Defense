using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(GameObject[] Towers)
    {
        foreach (GameObject Tower in Towers)
        {
            health -= 50;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }


    }

}
