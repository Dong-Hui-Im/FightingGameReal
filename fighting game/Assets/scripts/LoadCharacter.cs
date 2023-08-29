using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{

    private GameObject playerOneCharacter;

    private bool returnPlayerOnePlungerman;
    private bool returnPlayerOnePlaguedoctor;

    // Start is called before the first frame update
    void Start()
    {
        returnPlayerOnePlungerman = CharacterSelection.confirmedPlungermanPlayerOne;
        returnPlayerOnePlaguedoctor = CharacterSelection.confirmedPlaguedoctorPlayerOne;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadPlayerOneCharacter()
    {
        if (returnPlayerOnePlungerman == true)
        {
            Instantiate(Prefabs.Load("plungerman")) as GameObject;
        }

        if (returnPlayerOnePlaguedoctor == true)
        {
            Instantiate(Prefabs.Load("plaguedoctor")) as GameObject;
        }
    }
}
