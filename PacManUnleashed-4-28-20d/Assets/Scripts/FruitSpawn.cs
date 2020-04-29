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

    // eat ghost audio
    public AudioClip fruitChomp;
    public AudioSource audioSrc;

    void Start()
    {
        // Get audio volume
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", audioSrc.volume);
    }

    // Start is called before the first frame update
    void Update()
    {
        if(PacmanController.pacdotCounter == num_pacdots && PacmanController.level==spawnlevel && spawned==0)
        {
            clone=GameObject.Instantiate(fruit, transform.position, transform.rotation);
            spawned=1;
        }

        if(PacmanController.level!=spawnlevel)
        {
           clone.SetActive(false);    // destory fruit
           this.gameObject.SetActive(false);     
        }
    }

    void OnTriggerEnter(Collider co) {

        if(spawned == 1)
        {
            if (co.CompareTag("Pacman"))
            {   // if pacman collides into fruit
                // add score and health
                Score.score += points;
                PacmanController.health++;
                // play level up audio
                audioSrc.PlayOneShot(fruitChomp, audioSrc.volume);
                clone.SetActive(false);    // destory fruit
                this.gameObject.SetActive(false);  
            }
        }
            
    }

}
