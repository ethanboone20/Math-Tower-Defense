using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int money;
    public int startMoney = 300;

    public static int lives;
    public int startLives = 10;

    public static int waves;

    void Start()
    {
        money = startMoney;
        lives = startLives;
        waves = -1;
    }

}
