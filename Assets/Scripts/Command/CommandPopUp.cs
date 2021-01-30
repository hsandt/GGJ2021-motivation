using System.Collections;
using System.Collections.Generic;
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
        GenerateCommandButtons(activityDataArray);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void GenerateCommandButtons(ActivityData[] activityDataArray)
    {
        // we need one button per activity, +1 for Close
        int requiredButtonsCount = activityDataArray.Length + 1;
        
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
        for (int i = 0; i < activityDataArray.Length; i++)
        {
            ActivityData activityData = activityDataArray[i];
            GameObject commandButton = commandButtonsParent.GetChild(i).gameObject;
            var command = commandButton.GetComponentOrFail<Command>();
            command.AssignActivity(activityData);
            commandButton.SetActive(true);
        }
        
        // Setup the close button
        GameObject closeCommandButton = commandButtonsParent.GetChild(requiredButtonsCount - 1).gameObject;
        var closeCommand = closeCommandButton.GetComponentOrFail<Command>();
        closeCommand.AssignCloseAction();
        closeCommandButton.SetActive(true);
    }
}
