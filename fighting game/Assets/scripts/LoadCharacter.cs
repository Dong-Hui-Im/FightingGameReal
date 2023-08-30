using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{

    private GameObject playerOneCharacter;

    private bool returnPlayerOnePlungerman;
    private bool returnPlayerOnePlaguedoctor;

    private bool returnPlayerTwoPlungerman;
    private bool returnPlayerTwoPlaguedoctor;

    public GameObject plungermanOnePrefab;
    public GameObject plaguedoctorOnePrefab;
    public GameObject plungermanTwoPrefab;
    public GameObject plaguedoctorTwoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        returnPlayerOnePlungerman = CharacterSelection.confirmedPlungermanPlayerOne;
        returnPlayerOnePlaguedoctor = CharacterSelection.confirmedPlaguedoctorPlayerOne;

        returnPlayerTwoPlungerman = CharacterSelection2.confirmedPlungermanPlayerTwo;
        returnPlayerTwoPlaguedoctor = CharacterSelection2.confirmedPlaguedoctorPlayerTwo;

        LoadPlayerOneCharacter();
        LoadPlayerTwoCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadPlayerOneCharacter()
    {
        if (returnPlayerOnePlungerman == true)
        {
            Instantiate(plungermanOnePrefab);
        }

        if (returnPlayerOnePlaguedoctor == true)
        {
            Instantiate(plaguedoctorOnePrefab);
        }
    }

    void LoadPlayerTwoCharacter()
    {
        if (returnPlayerTwoPlungerman == true)
        {
            Instantiate(plungermanTwoPrefab);
        }

        if (returnPlayerTwoPlaguedoctor == true)
        {
            Instantiate(plaguedoctorTwoPrefab);
        }
    }
}
