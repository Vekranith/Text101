using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // Game Object References
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] State endGameState;
    [SerializeField] State characterState;

    // Player Stats
    public int strength;
    public int charisma;
    public int appraisal;
    public int gold;
    public int barter;

    // Stats Handling
        // Stats to add
    int strengthToAdd;
    int charismaToAdd;
    int appraisalToAdd;
    int goldToAdd;
    int barterToAdd;

        // Stats required to pick a choice
    int strengthNeeded;
    int charismaNeeded;
    int appraisalNeeded;
    int goldNeeded;
    int barterNeeded;

    // Dynamic Variables
    State state;
    State tempState;
    bool isCharSheetActive;
    bool canProgress;

    // Start is called before the first frame update
    void Start()
    {

        state = startingState;
        textComponent.text = state.GetStateStory();
        Debug.Log(state.GetNextStates());

    }

    // Update is called once per frame
    void Update()
    {

        ManageState();

    }

    private void CheckStats()
    {

        Debug.Log("Strength: " + strength);
        Debug.Log("Charisma: " + charisma);
        Debug.Log("Appraisal: " + appraisal);
        Debug.Log("Gold: " + gold);
        Debug.Log("Barter: " + barter);

    }

    private void CheckStatsToAdd()
    {
        //Debug.Log("CheckStatsToAdd called.");
        int[] statsToAdd = state.GetStatsToAdd();

        if (statsToAdd[0] == 0 && statsToAdd[1] == 0 && statsToAdd[2] == 0 && statsToAdd[3] == 0 && statsToAdd[4] == 0)
        {
            Debug.Log("Nothing to add.");
            return;
        }

        if (statsToAdd[0] > 0)
        {
            strengthToAdd = statsToAdd[0];
            //Debug.Log("Strength to add: " + strengthToAdd);
        }

        if (statsToAdd[1] > 0)
        {
            charismaToAdd = statsToAdd[1];
            //Debug.Log("Charisma to add: " + charismaToAdd);
        }

        if (statsToAdd[2] > 0)
        {
            appraisalToAdd = statsToAdd[2];
            //Debug.Log("Appraisal to add: " + appraisalToAdd);
        }

        if (statsToAdd[3] > 0)
        {
            goldToAdd = statsToAdd[3];
            //Debug.Log("Gold to add: " + goldToAdd);
        }

        if (statsToAdd[4] > 0)
        {
            barterToAdd = statsToAdd[4];
            //Debug.Log("Barter to add: " + barterToAdd);
        }

        // Debug.Log("Stats Updated.");
        // CheckStats();

    }

    private void AddStats()
    {

        strength = strength + strengthToAdd;
        strengthToAdd = 0;
        charisma = charisma + charismaToAdd;
        charismaToAdd = 0;
        appraisal = charisma + charismaToAdd;
        appraisalToAdd = 0;
        gold = gold + goldToAdd;
        goldToAdd = 0;
        barter = barter + barterToAdd;
        barterToAdd = 0;

    }

    private void CheckStatsNeeded()
    {
        Debug.Log("Stats needed check initiated.");
        int[] statsNeeded = state.GetStatsNeeded();
        Debug.Log("Array found.");

        strengthNeeded = statsNeeded[0];
        Debug.Log("Strength Needed = " + strengthNeeded);
        charismaNeeded = statsNeeded[1];
        Debug.Log("Charisma = " + charismaNeeded);
        appraisalNeeded = statsNeeded[2];
        Debug.Log("Appraisal Needed = " + appraisalNeeded);
        goldNeeded = statsNeeded[3];
        Debug.Log("Gold Needed = " + goldNeeded);
        barterNeeded = statsNeeded[4];
        Debug.Log("Barter Needed = " + barterNeeded);
        Debug.Log("Stats set.");

        if (strength >= strengthNeeded && charisma >= charismaNeeded && appraisal >= appraisalNeeded && gold >= goldNeeded && barter >= barterNeeded)
        {
            canProgress = true;
        }

        Debug.Log("Can Progress? " + canProgress);

    }

    private void ManageState()
    {

        var nextStates = state.GetNextStates();

        if (Input.GetKeyDown(KeyCode.End))
        {
            state = endGameState;
        }

        else if (Input.GetKeyDown(KeyCode.C) && isCharSheetActive == false)
        {
            tempState = state;
            state = characterState;
            CheckStats();
            isCharSheetActive = true;
        }

        else if (Input.GetKeyDown(KeyCode.C) && isCharSheetActive == true)
        {
            state = tempState;
            isCharSheetActive = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //CheckStats();
            CheckStatsNeeded();
            if (canProgress == true)
            {
                state = nextStates[0];
                CheckStatsToAdd();
                AddStats();
            }
            canProgress = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //CheckStats();
            CheckStatsNeeded();
            if (canProgress == true)
            {
                state = nextStates[1];
                CheckStatsToAdd();
                AddStats();
            }
            canProgress = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //CheckStats();
            CheckStatsNeeded();
            if (canProgress == true)
            {
                state = nextStates[2];
                CheckStatsToAdd();
                AddStats();
            }
            canProgress = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //CheckStats();
            CheckStatsNeeded();
            if (canProgress == true)
            {
                state = nextStates[3];
                CheckStatsToAdd();
                AddStats();
            }
            canProgress = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //CheckStats();
            CheckStatsNeeded();
            if (canProgress == true)
            {
                state = nextStates[4];
                CheckStatsToAdd();
                AddStats();
            }
            canProgress = false;
        }

        textComponent.text = state.GetStateStory();

    }
}
