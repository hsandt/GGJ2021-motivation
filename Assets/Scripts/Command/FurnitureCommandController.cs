using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureCommandController : MonoBehaviour
{
    [Header("Parameters")]

    [Tooltip("Array of activity data available for this furniture")]
    public ActivityData[] activityDataArray;


    public void ShowCommandPopUpForAvailableActivities()
    {
        ActivityManager.Instance.ShowCommandPopUp(activityDataArray);
    }
}
