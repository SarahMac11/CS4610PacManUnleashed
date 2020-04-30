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
        highScore.text = "HIGH SCORE" + "\n" + PlayerPrefs.GetInt("HighScore").ToString();
    }

}