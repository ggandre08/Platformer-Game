using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeCoins : MonoBehaviour
{
    public GameManager manager;
    public GameObject[] cherries;
    public Text coinsText;


    // Update is called once per frame
    void Update()
    {
        cherries = GameObject.FindGameObjectsWithTag("Cherry");
        if(cherries.Length == 0) //SI ya no hay cherries
        {
            manager.FinishLevel();
        }
        //Total de monedas del juego//Update UI
        coinsText.text = "x" + cherries.Length;
    }
}
