using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{

    // Inspector text
    [TextArea(10, 14)] [SerializeField] string storyText;
    
    // Array of stats to add
    [SerializeField] int[] statsToAdd = { 0, 0, 0, 0, 0 };

    // Array of stats needed
    [SerializeField] int[] statsNeeded = { 0, 0, 0, 0, 0 };

    // Array of possible states/choices
    [SerializeField] State[] nextStates;

    // Get the text of the current state
    public string GetStateStory()
    {

        return storyText;

    }

    // Get the possible state choices
    public State[] GetNextStates()
    {

        return nextStates;

    }

    public int[] GetStatsToAdd()
    {

        return statsToAdd;

    }
    
    public int[] GetStatsNeeded()
    {

        Debug.Log("Stats Needed Array: " + statsNeeded[0] + statsNeeded[1] + statsNeeded[2] + statsNeeded[3] + statsNeeded[4]);
        return statsNeeded;

    }

}
