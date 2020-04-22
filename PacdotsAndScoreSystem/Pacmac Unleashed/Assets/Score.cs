using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0;
    public Text scoreTxt;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;    // default start score
        scoreTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString("f0");   // display current score
    }
    
    // react to collision
    void ApplyPoints(float pacdot) {
        score += pacdot;    // increment score
        Update ();  // Update score with react
    }
}
