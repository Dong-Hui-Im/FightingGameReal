using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class RoundManager : MonoBehaviour
{
    public int playerOneWinCounter = 0;
    public int playerTwoWinCounter = 0;

    private Vector3[] initialPositions;  // Store the initial positions of objects
    private Transform[] objectsToReset;  // List of objects to reset

    public Toggle playerOneCheckBoxOne;
    public Toggle playerOneCheckBoxTwo;
    public Toggle playerTwoCheckBoxOne;
    public Toggle playerTwoCheckBoxTwo;

    public GameObject roundOne;
    public GameObject roundTwo;
    public GameObject roundThree;


    // Start is called before the first frame update
    void Awake()
    {
        // Initialize the array of initial positions and the list of objects to reset
        objectsToReset = new Transform[transform.childCount];
        initialPositions = new Vector3[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            objectsToReset[i] = transform.GetChild(i);
            initialPositions[i] = objectsToReset[i].position;
        }

        roundOne.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOneHealthBar.health <= 10)
        {
            PlayerOneHealthBar.health = 100;
            PlayerTwoHealthBar.health = 100;
            playerTwoWinCounter++;
            ResetPosition();
        }

        if (PlayerTwoHealthBar.health <= 10)
        {
            PlayerOneHealthBar.health = 100;
            PlayerTwoHealthBar.health = 100;
            playerOneWinCounter++;
            ResetPosition();
        }

        if (playerOneWinCounter == 1)
        {
            PlayerOneWinToggleOne();
            roundOne.SetActive(false);
            roundTwo.SetActive(true);
        }

        if (playerOneWinCounter == 2)
        {
            PlayerOneWinToggleTwo();
            SceneManager.LoadScene(4);
        }

        if (playerTwoWinCounter == 1)
        {
            PlayerTwoWinToggleOne();
            roundOne.SetActive(false);
            roundTwo.SetActive(true);
        }

        if (playerTwoWinCounter == 2)
        {
            PlayerTwoWinToggleTwo();
            SceneManager.LoadScene(5);
        }

        if (playerOneWinCounter == 1 || playerTwoWinCounter == 1)
        {
            roundOne.SetActive(false);
            roundTwo.SetActive(false);
            roundThree.SetActive(true);
        }
    }

    public void ResetPosition()
    {
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].position = initialPositions[i];  // Reset position
        }
    }

    public void PlayerOneWin()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayerTwoWin()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayerOneWinToggleOne()
    {
        playerOneCheckBoxOne.isOn = true;
    }

    public void PlayerOneWinToggleTwo()
    {
        playerOneCheckBoxTwo.isOn = true;
    }

    public void PlayerTwoWinToggleOne()
    {
        playerTwoCheckBoxOne.isOn = true;
    }

    public void PlayerTwoWinToggleTwo()
    {
        playerTwoCheckBoxTwo.isOn = true;
    }
}
