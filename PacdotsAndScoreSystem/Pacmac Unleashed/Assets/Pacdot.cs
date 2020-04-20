using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    void OnTriggerEnter(Collider co) {
        if(co.name == "Pacman") {   // if pacman collides into pac dot
            gameObject.Find("Score").SendMessage("React");
            yield WaitForSeconds(0.5);
            Destroy(gameObject);    // destory game object
        }
    }
}
