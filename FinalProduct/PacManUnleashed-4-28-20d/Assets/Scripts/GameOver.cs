using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayGame()
    {
        // Load scene - 1 (main)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void HomePage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    
    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
