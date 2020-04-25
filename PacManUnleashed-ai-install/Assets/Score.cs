using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;    // initialize score to 0
    //Attach your own Font in the Inspector
//    public Font pacFont;

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
        // create box style
//        pacFont = (Font)Resources.Load("Fonts/PAC-FONT", typeof(Font));
//        GUIStyle style = new GUIStyle();
//        style.font = pacFont;
        GUI.Box(new Rect (30, 50, 80, 40), "SCORE " + "\n" + score.ToString());
    }
}
