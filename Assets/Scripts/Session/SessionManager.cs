using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;
using CommonsPattern;
using UnityConstants;

public class SessionManager : SingletonManager<SessionManager>
{
    [Header("External references")]

    [Tooltip("Pause Menu")]
    public PauseMenu pauseMenu;

    
    /* Cached external references */

    private GameplayValuesContainer m_GameplayValuesContainer;
    public GameplayValuesContainer GameplayValuesContainer => m_GameplayValuesContainer;
    
    
    /* Cached data references */

    private DifficultySetting m_DifficultySetting;

    
    /* State */
    
    private bool m_Paused;

    
    protected override void Init()
    {
        GameObject gameplayValuesContainerGameObject = GameObject.FindWithTag(Tags.GameplayValuesContainer);
        if (gameplayValuesContainerGameObject)
        {
            m_GameplayValuesContainer = gameplayValuesContainerGameObject.GetComponentOrFail<GameplayValuesContainer>();
        }
        else
        {
            Debug.LogError("No game object found with tag GameplayValuesContainer, cannot set m_GameplayValuesContainer.");
        }
        
        m_DifficultySetting = ResourcesUtil.LoadOrFail<DifficultySetting>("DifficultySetting");
    }

    private void Start()
    {
        SetupSession();
    }
    
    private void SetupSession()
    {
        m_Paused = false;
        pauseMenu.gameObject.SetActive(false);
        
        m_GameplayValuesContainer.writingProgress.Init(m_DifficultySetting.maxWritingProgress, m_DifficultySetting.initialWritingProgress);
        m_GameplayValuesContainer.motivation.Init(m_DifficultySetting.maxMotivation, m_DifficultySetting.initialMotivation);
    }
    

    public void TogglePause()
    {
        m_Paused = !m_Paused;

        if (m_Paused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        //Time.timeScale = 0f;
        pauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.gameObject.SetActive(false);
    }
    
    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
