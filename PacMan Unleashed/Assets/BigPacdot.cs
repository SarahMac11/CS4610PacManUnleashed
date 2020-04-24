using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPacdot : MonoBehaviour
{
    void OnTriggerEnter(Collider co) {
        if(co.gameObject.name == "Pacman") {   // if pacman collides into pac dot
        
        // send react message
//        gameObject.SendMessage("ApplyPoints", 20.0);
        Destroy(this.gameObject);    // destory pac dot game object
        }
    }
}
