using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;    // initialize score to 0
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if(score == 1000) {
            PacmanController.health++;
            print("score health " + PacmanController.health);
        }
        if(score == 2000) {
            PacmanController.health++;
            print("score health " + PacmanController.health);
        }
    }
    
    void OnGUI() {
        GUI.Box(new Rect (50, 50, 75, 50), "SCORE " + "\n" + score.ToString());
    }
}
