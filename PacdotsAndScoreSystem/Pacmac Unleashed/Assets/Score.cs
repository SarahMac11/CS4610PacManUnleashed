using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    var Counter : score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;    // default start score
        scoreTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString("f0");
    }
    
    // react to collision
    void React() {
        score += 10;    // increment score
    }
}
