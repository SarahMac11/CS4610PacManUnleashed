using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float score = 0;
    public TextMesh scoreTxt;
    public string displayText;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;    // default start score
        scoreTxt = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        displayText = "SCORE " + score;
        scoreTxt.text = displayText;   // display current score
    }
    
    // react to collision
    void ApplyPoints(float pacdot) {
        score += pacdot;    // increment score
        Update ();  // Update score with react
    }
}
