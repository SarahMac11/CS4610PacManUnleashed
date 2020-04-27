using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayHighScore : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<TextMeshProUGUI> ();
        
//        // update text score
//        highScore.text = "HIGH SCORE " + Score.score.ToString();

//    if(SceneManager.GetActiveScene().name == "gameover") {
//            if(PlayerPrefs.GetInt("HighScore").ToString() == Score.score.ToString()) {
//                highScore.text = "NEW HIGH SCORE!" + "\n" + "HIGH SCORE" + "\n" + Score.score.ToString();
//            }
//        } else {
            // set starting high score as 0
            highScore.text = "HIGH SCORE" + "\n" + PlayerPrefs.GetInt("HighScore").ToString();
//        }
    }

}