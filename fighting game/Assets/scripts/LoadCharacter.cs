using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{

    private GameObject playerOneCharacter;

    private bool returnPlungerman;
    private bool returnPlaguedoctor;

    // Start is called before the first frame update
    void Start()
    {
        returnPlungerman = CharacterSelection.chosenPlayerOne;
        returnPlaguedoctor = CharacterSelection.chosenPlayerOne;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadPlayerOneCharacter()
    {
        if (returnPlungerman == true)
        {
            Instantiate(Prefabs.Load("plungerman")) as GameObject;
        }

        if (returnPlaguedoctor == true)
        {
            Instantiate(Prefabs.Load("plaguedoctor")) as GameObject;
        }
    }
}
