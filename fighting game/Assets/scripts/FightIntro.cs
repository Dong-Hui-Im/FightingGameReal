using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FightIntro : MonoBehaviour
{
    private int roundCounter;

    private float fightIntroFadeValue;
    private float fightIntroFadeSpeed = 0.33f;
    private FightIntroState fightIntroState;

    public static bool fightIntroFinished;

    public bool displayingRound;
    public bool displayingFight;

    public TextMeshProUGUI roundOneText;
    public TextMeshProUGUI roundTwoText;
    public TextMeshProUGUI roundThreeText;
    public TextMeshProUGUI fightText;

    private enum FightIntroState
    {
        FightIntroInitialise = 0,
        FightIntroFadeInRound = 1,
        FightIntroFightAnnouncement = 2,

    }

    // Start is called before the first frame update
    void Start()
    {

        fightIntroFinished = false;

        fightIntroFadeValue = 0;
        roundCounter = 1;

        displayingFight = false;
        displayingRound = false;

        roundOneText.gameObject.SetActive(false);
        roundTwoText.gameObject.SetActive(false);
        roundThreeText.gameObject.SetActive(false);
        fightText.gameObject.SetActive(false);

        StartCoroutine("FightIntroManager");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator FightIntroManager()
    {
        while (true)
        {
            switch (fightIntroState)
            {
                case FightIntroState.FightIntroInitialise:
                    FightIntroInitialise();
                    break;

                case FightIntroState.FightIntroFadeInRound:
                    FightIntroFadeInRound();
                    break;

                case FightIntroState.FightIntroFightAnnouncement:
                    FightIntroFightAnnouncement();
                    break;
            }
            yield return null;
        }
    }
    void FightIntroInitialise()
    {
        Debug.Log("FightIntroInitialise");

        displayingRound = true;

        fightIntroState = FightIntro.FightIntroState.FightIntroFadeInRound;  // Set FIght intro state to equal the fight intro fade in round
    }

    void FightIntroFadeInRound()
    {
        Debug.Log("FightIntroFadeInRound");

        fightIntroFadeValue += fightIntroFadeSpeed * Time.deltaTime;

        if (fightIntroFadeValue > 1)

        {
            fightIntroFadeValue = 1;
        }

        if (fightIntroFadeValue == 1)

        {
            displayingFight = true;
        }

        fightIntroState = FightIntro.FightIntroState.FightIntroFightAnnouncement;
    }

    void FightIntroFightAnnouncement()
    {
        Debug.Log("FightIntroFightAnnouncement");

        fightIntroFadeValue -= fightIntroFadeSpeed * 2 * Time.deltaTime;
    }

    void IncreaseRoundCounter()
    {
        Debug.Log("IncreaseRoundCounter");
        roundCounter++;
    }

    void OnGUI()
    {
        if (displayingRound == true)
        {
            if (roundCounter == 1)
            {
                roundOneText.gameObject.SetActive(true);
            }
        }
        if (displayingRound == true)
        {
            if (roundCounter == 2)
            {
                roundTwoText.gameObject.SetActive(true);
            }
        }
        if (displayingRound == true)
        {
            if (roundCounter == 3)
            {
                roundThreeText.gameObject.SetActive(true);
            }
        }
        if (displayingFight == true)
        {
            fightText.gameObject.SetActive(true);
        }
    }
}

