using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    // Health for life1
    public float totalHealth;
    public float damage;
    public float minimumHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        totalHealth = 3;    // default totalHealth
        damage = 1;         // default damage
        minimumHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        // if total health goes down, remove a life
        if(totalHealth == 2) {
            // destory life 3
            Destroy(GameObject.Find("Life3"));
        }
        if(totalHealth == 1) {
            // destory life 2
            Destroy(GameObject.Find("Life2"));
        }
        // if no more lives, end game
        if(totalHealth == 0) {
//            Application.Quit();
            // kill pacman here
        }
    }
    
    // call from ghost collision
    void GhostCollision(float damage) {
        totalHealth -= damage;  // decrement health
        Update ();
    }
}
