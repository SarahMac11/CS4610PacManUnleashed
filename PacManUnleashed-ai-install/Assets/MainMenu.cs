using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame () {
        // load level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
