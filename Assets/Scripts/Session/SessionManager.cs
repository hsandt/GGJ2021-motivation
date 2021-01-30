using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;
using CommonsPattern;
using UnityConstants;

public class SessionManager : SingletonManager<SessionManager>
{
    /* Cached external references */

    /// Writing Progress Gameplay Value
    private GameplayValue m_WritingProgress;
    
    /// Motivation Gameplay Value
    private GameplayValue m_Motivation;
    
    
    /* Cached data references */

    private DifficultySetting m_DifficultySetting;


    protected override void Init()
    {
        GameObject writingProgressGameObject = GameObject.FindWithTag(Tags.Gauge_WritingProgress);
        if (writingProgressGameObject)
        {
            m_WritingProgress = writingProgressGameObject.GetComponentOrFail<GameplayValue>();
        }
        else
        {
            Debug.LogError("No game object found with tag Gauge_WritingProgress, cannot set m_WritingProgress.");
        }
        
        GameObject motivationGameObject = GameObject.FindWithTag(Tags.Gauge_Motivation);
        if (motivationGameObject)
        {
            m_Motivation = motivationGameObject.GetComponentOrFail<GameplayValue>();
        }
        else
        {
            Debug.LogError("No game object found with tag Gauge_Motivation, cannot set m_Motivation.");
        }
        
        m_DifficultySetting = ResourcesUtil.LoadOrFail<DifficultySetting>("DifficultySetting");
    }

    private void Start()
    {
        SetupSession();
    }
    
    private void SetupSession()
    {
        m_WritingProgress.Init(m_DifficultySetting.maxWritingProgress, m_DifficultySetting.initialWritingProgress);
        m_Motivation.Init(m_DifficultySetting.maxMotivation, m_DifficultySetting.initialMotivation);
    }
}
