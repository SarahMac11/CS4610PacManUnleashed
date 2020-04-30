using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;    // initialize score to 0

    public TextMeshProUGUI scoreText;

    // eat ghost audio
    public AudioClip extraLife;
    public AudioSource audioSrc;

    public float timeBetweenShots = 0.25f;
    private float timer;

    public bool newLife = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get audio volume
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", audioSrc.volume);

        scoreText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (score != 0 && score % 1000 == 0)
        {
            PacmanController.health++;
            // play extra life audio
            timer += Time.deltaTime;
            if (timer > timeBetweenShots)
            {
                audioSrc.PlayOneShot(extraLife, audioSrc.volume);
                timer = 0;
            }
            //audioSrc.PlayOneShot(extraLife, audioSrc.volume);
        }

        ShowScore();
    }

    void ShowScore()
    {
        // update text score
        scoreText.text = "SCORE" + "\n" + score.ToString();
    }

}
