using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public abstract class ActivityBehaviour : MonoBehaviour
{
    [Header("Data")]
    
    [Tooltip("Activity ID")]
    public ActivityData data;
    
    
    /* Cached external references */

    protected GameplayValuesContainer m_GameplayValuesContainer;

    protected void ChangeSessionGameplayValue(SessionGameplayValueType type, float deltaValue)
    {
        SessionManager.Instance.GetSessionGameplayValue(type).ChangeValue(deltaValue);
    }

    protected void ChangeCurrentChapterGameplayValue(ChapterGameplayValueType type, float deltaValue)
    {
        SessionManager.Instance.GetCurrentChapterGameplayValue(type).ChangeValue(deltaValue);
    }
    
    private void Start()
    {
        // copy cached reference already set on SessionManager (at Awake time)
        m_GameplayValuesContainer = SessionManager.Instance.GameplayValuesContainer;
    }

    public abstract void Execute();
}
