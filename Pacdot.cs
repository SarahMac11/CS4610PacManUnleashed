using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacdot : MonoBehaviour
{
    // audio source
    //    public AudioSource chomp;
   // public int pacdotCounter; 
    void Start() 
    {
        // Get audio
//        chomp = GetComponent<AudioSource> ();
    }
    void Update()
    {
        if(PacmanController.pacdotCounter == 280)
        {
           // Debug.Log("made it");
          //  Pacdot.SetActive(true);
        }
       // Debug.Log("test");
      //  this.gameObject.SetActive(true);
    }
    

    public void Reset()
    {
        //this.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider co) {
        if(co.gameObject.name == "Pacman") {   // if pacman collides into pac dot
        
//            chomp.Play();
            // send react message
            Score.score += 10;
            this.gameObject.SetActive(false);
            // destory pac dot game object
        }
    }
    
}