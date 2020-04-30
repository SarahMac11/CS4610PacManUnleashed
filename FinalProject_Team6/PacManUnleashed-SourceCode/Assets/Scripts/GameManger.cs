using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    bool gameHasEnded = false;
    public void EndGame ()
    {
        if(gameHasEnded == false) 
        {
            gameHasEnded = true;
            Debug.Log("END GAME");
        }
    }
}
