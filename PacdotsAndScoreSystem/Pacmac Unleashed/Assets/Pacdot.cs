using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    void OnTriggerEnter(Collider co) {
        if(co.gameObject.name == "Pacman") {   // if pacman collides into pac dot
        
        // send react message
        gameObject.SendMessage("ApplyPoints", 10.0);
        Destroy(co.gameObject);    // destory pac dot game object
        }
    }
}
