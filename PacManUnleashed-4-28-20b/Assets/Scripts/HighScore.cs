using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<TextMeshProUGUI> ();
        
        // set starting high score as 0
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Score.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score.score);       // set high score
            highScore.text = "NEW HIGH SCORE!" + "\n" + "HIGH SCORE" + "\n" + Score.score.ToString();   // display high score
        }
        
        ShowHighScore();
    }
    
    void ShowHighScore() 
    {  
        // update text score
        highScore.text = "HIGH SCORE " + Score.score.ToString();
    }
}
