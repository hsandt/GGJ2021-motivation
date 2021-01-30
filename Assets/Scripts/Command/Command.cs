using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using CommonsHelper;

/// Command usable by player when selecting furniture
/// Most are activities, but there may be special commands like Cancel
public class Command : MonoBehaviour
{
    [Header("Children references")]

    [Tooltip("Button text widget")]
    public TextMeshProUGUI buttonTextWidget;
    
    
    /* Sibling components */
    
    private Button button;
    
    
    void Awake()
    {
        button = this.GetComponentOrFail<Button>();
    }

    public void AssignActivity(ActivityData activityData)
    {
        buttonTextWidget.text = activityData.activityName;
        
        // we use pooling so this button may have been used for something else, so clear listeners first
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => { ActivityManager.Instance.StartActivity(activityData.id); });
    }
}
