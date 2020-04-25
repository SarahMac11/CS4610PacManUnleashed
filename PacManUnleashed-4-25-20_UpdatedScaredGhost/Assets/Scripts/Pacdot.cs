using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pacdot : MonoBehaviour
{
    
    void OnTriggerEnter(Collider co) {
        if(co.gameObject.name == "Pacman") {   // if pacman collides into pac dot
        
        // send react message
        Score.score += 10;
        Destroy(this.gameObject);    // destory pac dot game object
        }
    }
    
}