using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
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
        scoreText = GetComponent<TextMeshProUGUI> ();
        
    }
    
    // Update is called once per frame
    void Update()
    {   
        if(score == 1000) {
            PacmanController.health++;
            print("score health " + PacmanController.health);
            // Play new life audio
            extraLife.Play();
        }
        if(score == 2000) {
            PacmanController.health++;
            print("score health " + PacmanController.health);
            // Play new life audio
            extraLife.Play();
        }
        if(score == 3000) {
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
