using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUp : MonoBehaviour
{
    public static int level = 1;        // start level at 1
    public int oldVal = 0;
    
    public TextMeshProUGUI levelText;
    
    // eat ghost audio
    public AudioClip levelUp;
    public AudioSource audioSrc;
    public static bool newLevelUpdate = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get audio volume
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", audioSrc.volume);
        
        levelText = GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        level = PacmanController.level;
        if(level > oldVal) {
            newLevelUpdate = true;
            showLevelUp();
            showLevel();
            oldVal = level;
            // play level up audio
            audioSrc.PlayOneShot(levelUp, audioSrc.volume);
            
        } else {
            newLevelUpdate = false;
            showLevel();
        }
    }
    
    void showLevel()
    {
        // update text score
        levelText.text = "LEVEL " + level.ToString();
    }
    
    void showLevelUp() {
        print("LEVEL UP");
        levelText.text = "LEVEL UP!" + "\n" + "LEVEL " + level.ToString();
    }
}
