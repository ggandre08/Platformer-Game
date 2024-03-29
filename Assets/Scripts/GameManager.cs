using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int totalCoins = 0;
    public int lives = 3;
    public Transform spawnPoint;
    public PlayerController player;
    public float timeToRespawn = 2f;
    private float timer = 0;
    public bool isGameOver = false;
    public bool isLevelFinished = false;
    public Text lifesText;
    public GameObject levelEndPanel;
    public Text levelEndText;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isAlive == false)
        {
            if (timer < timeToRespawn)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                if (lives > 0)
                {
                    lives--;
                    player.transform.position = spawnPoint.transform.position;
                    player.isAlive = true;
                    timer = 0f;
                }
                else
                {
                    isGameOver = true;
                }

            }

        }

        if (isGameOver == true || isLevelFinished == true)
        {

            levelEndPanel.SetActive(true); //Activa el panel

            if (isGameOver)
            {
                levelEndText.text = "GAMEOVER";
            }

            if (isLevelFinished)
            {
                levelEndText.text = "FINISHED";
            }

            if (Input.GetKeyDown(KeyCode.Escape)) {
                //Load Main Menu
                SceneManager.LoadScene(0);
            }
        }

        lifesText.text = "x" + lives; //Se a�aden cosas al texto
    }

    public void FinishLevel()
    {
        isLevelFinished = true;//Se acaba el nivel


    }

}
