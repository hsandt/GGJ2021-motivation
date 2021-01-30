using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;
using CommonsPattern;

public class SessionManager : SingletonManager<SessionManager>
{
    [Header("External references")]

    [Tooltip("Writing Progress Gameplay Value")]
    public GameplayValue writingProgress;
    
    [Tooltip("Motivation Gameplay Value")]
    public GameplayValue motivation;
    
    
    /* Cached data references */

    private DifficultySetting m_difficultySetting;


    private void Awake()
    {
        m_difficultySetting = ResourcesUtil.LoadOrFail<DifficultySetting>("DifficultySetting");
    }

    private void Start()
    {
        SetupSession();
    }
    
    private void SetupSession()
    {
        writingProgress.Init(m_difficultySetting.maxWritingProgress, m_difficultySetting.initialWritingProgress);
        motivation.Init(m_difficultySetting.maxMotivation, m_difficultySetting.initialMotivation);
    }
}