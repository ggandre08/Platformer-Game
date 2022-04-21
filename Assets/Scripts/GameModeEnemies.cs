using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeEnemies : MonoBehaviour
{
    public GameManager manager;
    public GameObject[] enemies;
    public Text enemyText;


    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) //SI ya no hay cherries
        {
            manager.FinishLevel();
        }

        //Update UI
        enemyText.text = "x" + enemies.Length;
    }
}

