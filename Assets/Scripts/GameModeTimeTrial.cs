using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeTimeTrial : MonoBehaviour
{
    public GameManager manager;
    public float levelTimer = 35f;
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        if(levelTimer > 0) {
           levelTimer = levelTimer - Time.deltaTime; //Va bajando de 1 en 1
        }
        else  {
            if(manager.isGameOver == false)  {
               manager.isGameOver = true;
               manager.player.Die();
            }
        }

        //Update UI //Recorta los decimales del texto 
        timeText.text = "Time: " + levelTimer.ToString("F1");
    }
}
