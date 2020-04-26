using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacdot : MonoBehaviour
{
    // audio source
    public AudioSource chomp;
//    public AudioClip coSound;
    
    // Use this for initiation
    void Start () {
        chomp = GetComponent<AudioSource> ();
    }
    
    void OnTriggerEnter(Collider co) {
        if(co.gameObject.name == "Pacman") {   // if pacman collides into pac dot
        
        // chomp sound
        chomp.Play();
        
        // send react message
        Score.score += 10;
        Destroy(this.gameObject);    // destory pac dot game object
        }
    }
    
}