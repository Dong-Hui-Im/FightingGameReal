using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

[Serializable]

public class CharacterSelection : MonoBehaviour
{
    // list variables
    private GameObject[] characterList;
    private int index = 0;

    private void Start()
    {
        //  the index is equal to the 'first character selected'
        index = PlayerPrefs.GetInt("FirstCharacterSelected");
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
        if(index < 0)
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
        // set the first character that the player has selected, and move  on to the next scene
        PlayerPrefs.SetInt("FirstCharacterSelected", index);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // defines the spawn position and spawns the chosen character in that location
        Vector3 spawnPositionPlayerOne = new Vector3(-22.8f, 14f, -0.4f);
        Instantiate(characterList[index], spawnPositionPlayerOne, characterList[index].transform.rotation);
        characterList[index].SetActive(true);
    }
}
