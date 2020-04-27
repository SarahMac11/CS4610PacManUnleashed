using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<TextMeshProUGUI> ();
        
        // set starting high score as 0
        highScore.text = "HIGH SCORE" + "\n" + PlayerPrefs.GetInt("HighScore").ToString();
    }

}
