using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public GameObject fruit;
    public GameObject clone;
    
    public int num_pacdots; //num_pacdot refers to the amount of pacdots left in maze before fruit is spawned
    public int spawnlevel; //level where fruit will spawn
    public int points; //how many points fruit are worth
    public int spawned = 0;

    // Start is called before the first frame update
    void Update()
    {
        if(PacmanController.pacdotCounter == num_pacdots && PacmanController.level==spawnlevel && spawned==0)
        {
         clone=GameObject.Instantiate(fruit, transform.position, transform.rotation);
         spawned=1;
        }
    }

    void OnTriggerEnter(Collider co) {
        
            if (co.CompareTag("Pacman")) {   // if pacman collides into fruit
                Score.score += points;
                clone.SetActive(false);    // destory fruit
        }
    }

}
