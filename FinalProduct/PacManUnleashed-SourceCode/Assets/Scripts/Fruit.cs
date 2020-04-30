using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    // eat ghost audio
    public AudioClip fruitChomp;
    public AudioSource audioSrc;

    // public int pacdotCounter; 
    void Start()
    {
        // Get audio volume
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", audioSrc.volume);
    }
    void Update()
    {
        //if (PacmanController.fruitCounter == 4)
        //{
            // Debug.Log("made it");
            //  Pacdot.SetActive(true);
        //}
        // Debug.Log("test");
        //  this.gameObject.SetActive(true);
    }


    public void Reset()
    {
        //this.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.name == "Pacman")
        {   // if pacman collides into pac dot

            // send react message
            //Score.score += 200;
            // play level up audio
            audioSrc.PlayOneShot(fruitChomp, audioSrc.volume);
            this.gameObject.SetActive(false);
            // destory pac dot game object
        }
    }

}
