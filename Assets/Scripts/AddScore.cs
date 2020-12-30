using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{

    // public AudioClip scoredAudio;
    private AudioSource audioSource;

    private bool isHighScore = false;

    void Start(){
        audioSource = GetComponent<AudioSource> ();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 9){
            Score.score++;
                    
            audioSource.Play();

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
