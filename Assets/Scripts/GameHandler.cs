﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public GameObject PauseScreenCanvas;
    public GameObject PauseCanvas;
    public GameObject InstructionCanvas;


    public static float obstacleSpeed = 25f;

    private int scoreCheck = 10;
    public GameObject YourScoreText;
    public GameObject GameHighScoreText;
    public GameObject[] Obstacles;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Game Start");
        GameOverCanvas.SetActive(false);
        PauseScreenCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        InstructionCanvas.SetActive(true);


        Time.timeScale = 0;
    }

    void Update(){
        if (Score.score%scoreCheck==0 && Score.score != 0){
            obstacleSpeed += 1f;
        }
    }
    public void gameOver(){
        Debug.Log("gameOver() function called");

        YourScoreText.GetComponent<UnityEngine.UI.Text>().text = "Your Score : " + Score.score.ToString();
        GameHighScoreText.GetComponent<UnityEngine.UI.Text>().text = "High Score : " + HighScore.highScore.ToString();

        // System.Threading.Thread.Sleep(3000);
        GameOverCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        Time.timeScale = 0;

    }

    public void resetGame(){
        
        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        for(var i = 0 ; i < Obstacles.Length ; i ++)
            {
                Destroy(Obstacles[i]);
            }

        obstacleSpeed = 25f;

    }

    public void replay(){

        resetGame();

        SceneManager.LoadScene(0);
        InstructionCanvas.SetActive(false);//not working

    }

    public void startGame(){
        // SceneManager.LoadScene(0);
        obstacleSpeed = 25f;
        InstructionCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        Time.timeScale = 1;

    }

    public void pauseGame(){
        PauseScreenCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        Time.timeScale = 0;
    }

    public void resumeGame(){
        PauseScreenCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void saveGameData(){
        Debug.Log("Game Data Saved!!");
    }

}
