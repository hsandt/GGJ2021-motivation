using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;
using CommonsPattern;
using UnityConstants;

public class SessionManager : SingletonManager<SessionManager>, IGameplayValueObserver
{
    [Header("Assets references")]

    [Tooltip("Difficulty setting to use for this session")]
    public DifficultySetting difficultySetting;

    
    [Header("External references")]

    [Tooltip("Pause Menu")]
    public PauseMenu pauseMenu;

    
    /* Cached external references */

    private GameplayValuesContainer m_GameplayValuesContainer;
    public GameplayValuesContainer GameplayValuesContainer => m_GameplayValuesContainer;
    
    
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
    }

    private void Start()
    {
        SetupSession();
    }
    
    private void SetupSession()
    {
        StartCoroutine(SetupAsync());
    }

    private IEnumerator SetupAsync()
    {
        SetupSessionInstant();
        // wait 1 frame so all gameplay value observers are registered (including SessionManager itself)
        yield return null;
        SetupSessionDelayed();
    }
    
    private void SetupSessionInstant()
    {
        m_Paused = false;
        pauseMenu.gameObject.SetActive(false);

        // track progress for Victory
        m_GameplayValuesContainer.writingProgress.RegisterObserver(this);
    }

    private void SetupSessionDelayed()
    {
        m_GameplayValuesContainer.writingProgress.Init(difficultySetting.maxWritingProgress, difficultySetting.initialWritingProgress);
        m_GameplayValuesContainer.motivation.Init(difficultySetting.maxMotivation, difficultySetting.initialMotivation);
    }
    
    private void OnDestroy()
    {
        if (m_GameplayValuesContainer.writingProgress)
        {
            m_GameplayValuesContainer.writingProgress.UnregisterObserver(this);
        }
    }

    public void TogglePause()
    {
        if (!m_Paused)
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
        m_Paused = true;
        pauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
//        Time.timeScale = 1.0f;
        m_Paused = false;
        pauseMenu.gameObject.SetActive(false);
    }
    
    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void NotifyValueChange()
    {
        // progress changed, check if complete
        if (m_GameplayValuesContainer.writingProgress.GetRatio() >= 1f)
        {
            // success!
            TutorialManager.Instance.ShowMessage(MessageEnum.Success);
        }
    }
}
