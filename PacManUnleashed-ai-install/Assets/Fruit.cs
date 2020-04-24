using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    void OnTriggerEnter(Collider co) {
        if(co.gameObject.name == "Pacman") {   // if pacman collides into pac dot
        
            Score.score += 50;
            PacmanController.health++;
            print("fruit health " + PacmanController.health);
            Destroy(this.gameObject);    // destroy fruit
        }
    }
}
