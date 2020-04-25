using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPacdot : MonoBehaviour
{
    void OnTriggerEnter(Collider co) {
        if(co.gameObject.name == "Pacman") {   // if pacman collides into pac dot
        
        Score.score += 20;
        Destroy(this.gameObject);    // destory pac dot game object
        }
    }
}
