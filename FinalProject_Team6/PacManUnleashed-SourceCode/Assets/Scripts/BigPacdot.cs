using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPacdot : MonoBehaviour
{

    void Start()
    {

    }

    void OnTriggerEnter(Collider co)
    {

        if (co.gameObject.name == "Pacman")
        {   // if pacman collides into pac dot

            //Used to change ghosts to scared mode
            GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject go in ghosts)
            {
                go.GetComponent<GhostFollow>().startScaredGhost();
            }

            Score.score += 30;
            this.gameObject.SetActive(false);   // destory pac dot game object
        }
    }
}
