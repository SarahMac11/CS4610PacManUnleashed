using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacdot : MonoBehaviour
{

    // public int pacdotCounter; 
    void Start()
    {

    }
    void Update()
    {

    }


    void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.name == "Pacman")
        {   // if pacman collides into pac dot

            // add 10 points
            Score.score += 10;
            // set not active
            this.gameObject.SetActive(false);
        }
    }

}