using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommonsHelper;
using UnityEngine;

/// Popup listing commands available for this furniture
public class CommandPopUp : MonoBehaviour
{
    [Header("Asset references")]
    
    [Tooltip("Prefab of command button")]
    public GameObject commandButtonPrefab;
    
    
    [Header("Children references")]

    [Tooltip("Parent of command buttons (where we will spawn them in code)")]
    public Transform commandButtonsParent;


    public void ShowWithActivities(ActivityData[] activityDataArray)
    {
        // make sure to activate just before assigning, in case it was deactivated in the Editor,
        // as component refs are cached on Command.Awake, and command buttons are children of this game object
        gameObject.SetActive(true);
        GenerateCommandButtons(activityDataArray);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void GenerateCommandButtons(ActivityData[] activityDataArray)
    {
        // filter actual activities to use (lock check)
        var filteredActivityDataArray = activityDataArray.Where(data => !data.lockedOnStart).ToArray();
        
        // we need one button per activity, +1 for Close
        int requiredButtonsCount = filteredActivityDataArray.Length + 1;
        
        // pool the buttons with lazy creation if needed:
        int previousButtonsCount = commandButtonsParent.childCount;
        
        // First, create new widgets if there are not enough in the pool
        for (int i = previousButtonsCount; i < requiredButtonsCount; i++)
        {
            Instantiate(commandButtonPrefab, commandButtonsParent);
        }

        // Second, disable any extra widgets we don't need now
        // First and Second are mutually exclusive cases
        for (int i = requiredButtonsCount; i < previousButtonsCount; i++)
        {
            commandButtonsParent.GetChild(i).gameObject.SetActive(false);
        }
        
        // Third, go over widgets actually used and set them up
        
        // Setup the activities
        for (int i = 0; i < filteredActivityDataArray.Length; i++)
        {
            ActivityData activityData = filteredActivityDataArray[i];
            GameObject commandButton = commandButtonsParent.GetChild(i).gameObject;
            var command = commandButton.GetComponentOrFail<Command>();
            // make sure to activate just before assigning, in case it was deactivated in the Editor,
            // as component refs are cached on Command.Awake
            commandButton.SetActive(true);
            command.AssignActivity(activityData);
        }
        
        // Setup the close button
        GameObject closeCommandButton = commandButtonsParent.GetChild(requiredButtonsCount - 1).gameObject;
        var closeCommand = closeCommandButton.GetComponentOrFail<Command>();
        closeCommandButton.SetActive(true);
        closeCommand.AssignCloseAction();
    }
}
