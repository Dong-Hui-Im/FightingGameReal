using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        // print quit because we can't actually see the window quit in unity 
        Debug.Log("Quit");
        // quit the application
        Application.Quit();
    }
}
