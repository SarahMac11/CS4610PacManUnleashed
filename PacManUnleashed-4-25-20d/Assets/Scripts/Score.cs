﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;    // initialize score to 0
    
    public TextMeshProUGUI scoreText;
    
    // audio source
    public AudioSource extraLife;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get audio
        extraLife = GetComponent<AudioSource> ();
        // get slider volume level if set
//        extraLife.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", extraLife.volume);
        
        scoreText = GetComponent<TextMeshProUGUI> ();
        
    }
    
    // Update is called once per frame
    void Update()
    {   
        if(score != 0 && score % 1000 == 0) {
            PacmanController.health++;
            print("score health " + PacmanController.health);
            // Play new life audio
            extraLife.Play();
        }

        
        ShowScore();
    }
    
    void ShowScore() 
    {
        // update text score
        scoreText.text = "SCORE" + "\n" + score.ToString();
    }
}
