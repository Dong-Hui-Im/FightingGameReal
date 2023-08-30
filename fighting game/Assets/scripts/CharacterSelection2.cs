using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

[Serializable]

public class CharacterSelection2 : MonoBehaviour
{
    // list variables
    private GameObject[] characterList;
    private int index = 0;

    private bool chosenPlungermanPlayerTwo = false;
    private bool chosenPlaguedoctorPlayerTwo = false;

    public static bool confirmedPlungermanPlayerTwo = false;
    public static bool confirmedPlaguedoctorPlayerTwo = false;

    private void Start()
    {
        // character list created as a new gameobject each time
        characterList = new GameObject[transform.childCount];

        // fill the array
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        // toggle off their render
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        //we toggle on the selected character
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }

    public void ToggleLeft()
    {
        // toggle off the current model
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        // topple on the new model
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        // toggle off the current model
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        // topple on the new model
        characterList[index].SetActive(true);
    }

    public void ConfirmButton()
    {
        characterList[index].SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (index == 0)
        {
            chosenPlaguedoctorPlayerTwo = true;
        }

        if (index == 1)
        {
            chosenPlungermanPlayerTwo = true;
        }

        confirmedPlungermanPlayerTwo = chosenPlungermanPlayerTwo;
        confirmedPlaguedoctorPlayerTwo = chosenPlaguedoctorPlayerTwo;
    }
}
