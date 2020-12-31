using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public GameObject PauseScreenCanvas;
    public GameObject PauseCanvas;
    public GameObject InstructionCanvas;

    public AdManager adManager;

    public static float obstacleXSpeed = 25f;
    public static float obstacleYSpeed = 15f;

    private float maxObstacleXSpeed = 50f;
    private float maxObstacleYSpeed = 40f;

    private float obstacleRotationSpeed = 10f;

    private int scoreCheck = 10;

    public GameObject YourScoreText;
    public GameObject GameHighScoreText;
    public GameObject toggleMusicButton;
    public GameObject musicText;

    private GameObject[] Obstacles;
    private bool isGameStart = false;
    private bool isMusicOn = true;

    public Sprite musicOnImage;
    public Sprite musicOffImage;

    void Awake(){
        AudioListener.pause = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        adManager.initializeAd();
        // Debug.Log("Game Start");
        GameOverCanvas.SetActive(false);
        PauseScreenCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        InstructionCanvas.SetActive(true);
        Time.timeScale = 0;

        setIcons();

    }

    

    void Update(){

        
        if(  !isGameStart &&(  Input.GetTouch(0).phase == TouchPhase.Began)  ){
            isGameStart = true;
            startGame();
         }

        if (Score.score%scoreCheck==0 && Score.score != 0 
                && obstacleXSpeed <= maxObstacleXSpeed 
                && obstacleYSpeed <= maxObstacleYSpeed){

            obstacleXSpeed += 0.05f;
            obstacleYSpeed += 0.05f;
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
        adManager.displayVideoAD();

    }

    public void resetGame(){
        
        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        for(var i = 0 ; i < Obstacles.Length ; i ++)
            {
                Destroy(Obstacles[i]);
            }

        obstacleXSpeed = 25f;
        obstacleYSpeed = 15f;

    }

    public void replay(){

        resetGame();

        SceneManager.LoadScene(0);
        InstructionCanvas.SetActive(false);//not working

    }

    public void startGame(){
        AudioListener.pause = false;
        // SceneManager.LoadScene(0);
        obstacleXSpeed = 25f;
        obstacleYSpeed = 25f;
        InstructionCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        Time.timeScale = 1;

    }

    public void pauseGame(){
        AudioListener.pause = true;
        PauseScreenCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        Time.timeScale = 0;
    }

    public void resumeGame(){
        AudioListener.pause = false;
        PauseScreenCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void toggleMusic(){

        if(isMusicOn){
            toggleMusicButton.GetComponent<Image>().sprite = musicOffImage;
            musicText.GetComponent<UnityEngine.UI.Text>().text = "Sound : off";
            isMusicOn = false;
            AudioListener.volume = 0f;

        }
        else{
            toggleMusicButton.GetComponent<Image>().sprite = musicOnImage;
            musicText.GetComponent<UnityEngine.UI.Text>().text = "Sound : on";
            isMusicOn = true;
            AudioListener.volume = 1f;
        }
    }

    public void saveGameData(){
        Debug.Log("Game Data Saved!!");
    }

    public void setIcons(){
        if(AudioListener.volume == 0f){
            toggleMusicButton.GetComponent<Image>().sprite = musicOffImage;
            musicText.GetComponent<UnityEngine.UI.Text>().text = "Sound : off";
        }
        else if(AudioListener.volume == 1f){
            toggleMusicButton.GetComponent<Image>().sprite = musicOnImage;
            musicText.GetComponent<UnityEngine.UI.Text>().text = "Sound : on";
        }
    }

}
