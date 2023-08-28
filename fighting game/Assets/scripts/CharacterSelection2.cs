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
    private GameObject[] characterList2;
    private int indexTwo = 0;

    private void Start()
    {
        //  the index is equal to the 'second character selected'
        indexTwo = PlayerPrefs.GetInt("SecondCharacterSelected");
        // character list created as a new gameobject each time 
        characterList2 = new GameObject[transform.childCount];

        // fill the array
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList2[i] = transform.GetChild(i).gameObject;
        }

        // toggle off their render
        foreach (GameObject go in characterList2)
        {
            go.SetActive(false);
        }
    }

    public void ToggleLeft()
    {
        // toggle off the current model
        characterList2[indexTwo].SetActive(false);

        indexTwo--; // minus one to the 
        if(indexTwo < 0)
        {
            indexTwo = characterList2.Length - 1;
        }

        // topple on the new model
        characterList2[indexTwo].SetActive(true);
    }

    public void ToggleRight()
    {
        // toggle off the current model
        characterList2[indexTwo].SetActive(false);

        indexTwo++; // plus one to index two
        // if index two is too long for the list, reset it back to 0
        if (indexTwo == characterList2.Length)
        {
            indexTwo = 0;
        }

        // toggle on the new model
        characterList2[indexTwo].SetActive(true);
    }

    public void ConfirmButton()
    {
        // set the second character that the player has selected, and move  on to the next scene
        PlayerPrefs.SetInt("SecondCharacterSelected", indexTwo);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // defines the spawn position and spawns the chosen character in that location
        Vector3 spawnPositionPlayerTwo = new Vector3(21f, 8.8f, -0.4f);
        Instantiate(characterList2[indexTwo], spawnPositionPlayerTwo, characterList2[indexTwo].transform.rotation);
        characterList2[indexTwo].SetActive(true);
    }

}
