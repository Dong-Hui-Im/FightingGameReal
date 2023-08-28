using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // when play game is called... 
    public void PlayGame()
    {
        // load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // when quit game is called... 
    public void QuitGame()
    {
        // print quit because we can't actually see the window quit in unity 
        Debug.Log("Quit");
        // quit the application
        Application.Quit();
    }

}
