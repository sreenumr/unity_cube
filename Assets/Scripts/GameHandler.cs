﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameObject GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start");
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void gameOver(){
        Debug.Log("gameOver() function called");
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0;

    }

    public void replay(){
        SceneManager.LoadScene(0);
    }

    public void saveGameData(){
        Debug.Log("Game Data Saved!!");
    }

}
