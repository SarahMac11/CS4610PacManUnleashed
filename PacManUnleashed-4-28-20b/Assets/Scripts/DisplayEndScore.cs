using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayEndScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI> ();
        // update text score
        scoreText.text = "YOUR SCORE" + "\n" + Score.score.ToString();
    }
}
