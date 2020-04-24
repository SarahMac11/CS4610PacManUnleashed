using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostFollow : MonoBehaviour
{
    GameObject player;
     NavMeshAgent enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Pacman");
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.destination=player.transform.position;
    }

//    void OnTriggerEnter(Collider co) {
//        if(co.gameObject.name == "Pacman") {   // if pacman collides into pac dot
//            // decrement health
//        }
//    }
}
