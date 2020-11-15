using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{

    private bool isHighScore = false;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 9){
            Score.score++;

            if(Score.score > HighScore.highScore){
                isHighScore = true;
            }

            if(isHighScore){
                HighScore.highScore ++;
                PlayerPrefs.SetInt("highScore",HighScore.highScore);

            }

            PlayerPrefs.Save();
        }
            // Debug.Log("Score=" + Score.score);
    }
}
