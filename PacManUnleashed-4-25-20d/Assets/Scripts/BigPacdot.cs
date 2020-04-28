using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPacdot : MonoBehaviour
{
    // get audio source
    public AudioSource chomp;
    
    void Start() 
    {
        chomp = GetComponent<AudioSource> ();
        // get slider volume level if set
        chomp.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", chomp.volume);
    }
    
    void OnTriggerEnter(Collider co) {
        
        if(co.gameObject.name == "Pacman") {   // if pacman collides into pac dot
        
        //Used to change ghosts to scared mode
          GameObject[] ghosts =GameObject.FindGameObjectsWithTag("Enemy");
        
          foreach (GameObject go in ghosts)
          {
            go.GetComponent<GhostFollow> ().startScaredGhost ();
          }
          
        chomp.Play();
        Score.score += 20;
        this.gameObject.SetActive(false);   // destory pac dot game object
        }
    }
}
