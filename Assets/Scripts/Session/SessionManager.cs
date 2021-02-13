using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;
using CommonsPattern;
using UnityConstants;

using SessionGameplayValue = GameplayValue<SessionGameplayValueType>;
using ChapterGameplayValue = GameplayValue<ChapterGameplayValueType>;

public class SessionManager : SingletonManager<SessionManager>, IGameplayValueObserver
{
    [Header("Assets references")]

    [Tooltip("Difficulty setting to use for this session")]
    public DifficultySetting difficultySetting;

    [Tooltip("Activity game balance data")]
    public ActivityBalance activityBalance;

    
    [Header("External references")]

    [Tooltip("Pause Menu")]
    public PauseMenu pauseMenu;
    
    [Tooltip("Player character animator: if not set, find object with tag, but doesn't work if object is inactive")]
    public Animator playerCharacterAnimator;

    [Tooltip("Animator for items using in activities: if not set, find object with tag, but doesn't work if object is inactive")]
    public Animator activityItemsAnimator;

    
    /* Cached external references */

    private GameplayValuesContainer m_GameplayValuesContainer;
    public GameplayValuesContainer GameplayValuesContainer => m_GameplayValuesContainer;


    /* Observed values */

    private GameplayValue<ChapterGameplayValueType> m_LastChapterProgress;
    
    
    /* State */
    
    /// Is the game paused?
    private bool m_Paused;
    
    /// Current chapter index the character is working on
    private int m_CurrentChapterIndex;
    public int CurrentChapterIndex => m_CurrentChapterIndex;

    public SessionGameplayValue GetSessionGameplayValue(SessionGameplayValueType type)
    {
        return m_GameplayValuesContainer.GetSessionGameplayValue(type);
    }
    
    public ChapterGameplayValue GetCurrentChapterGameplayValue(ChapterGameplayValueType type)
    {
        return m_GameplayValuesContainer.GetChapterGameplayValue(m_CurrentChapterIndex, type);
    }
    
    
    protected override void Init()
    {
        GameObject gameplayValuesContainerGameObject = GameObject.FindWithTag(Tags.GameplayValuesContainer);
        if (gameplayValuesContainerGameObject)
        {
            m_GameplayValuesContainer = gameplayValuesContainerGameObject.GetComponentOrFail<GameplayValuesContainer>();
            
            // create gameplay value arrays early so this object, and others can register themselves as observers of these values
            m_GameplayValuesContainer.CreateGameplayValueArrays(difficultySetting);
        }
        else
        {
            Debug.LogError("No game object found with tag GameplayValuesContainer, cannot set m_GameplayValuesContainer.");
        }
        
        if (playerCharacterAnimator == null)
        {
            GameObject playerCharacter = GameObject.FindWithTag(Tags.Player);
            if (playerCharacter)
            {
                playerCharacterAnimator = playerCharacter.GetComponent<Animator>();
            }
            else
            {
                Debug.LogError("No game object found with tag Player, cannot set playerCharacterAnimator.");
            }
        }
        
        if (activityItemsAnimator == null)
        {
            GameObject activityItemsParent = GameObject.FindWithTag(Tags.ActivityItemsAnimator);
            if (activityItemsParent)
            {
                activityItemsAnimator = activityItemsParent.GetComponent<Animator>();
            }
            else
            {
                Debug.LogError("No game object found with tag ActivityItemsAnimator, cannot set activityItemsAnimator.");
            }
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

        m_CurrentChapterIndex = 0;

        // track progress for Victory by monitoring the last chapter's progress
        m_LastChapterProgress = m_GameplayValuesContainer.GetChapterGameplayValue(difficultySetting.chaptersCount - 1, ChapterGameplayValueType.WritingProgress);
        m_LastChapterProgress.RegisterObserver(this);
        
        // initialise multi-object animators so character starts working on desktop, with all activity items visible
        // aesthetics note: items will fade in after scene load!
        playerCharacterAnimator.SetInteger(AnimatorParameters.poseIndexHash, (int)CharacterPoseEnum.WorkingAtPCPosesV05);
        activityItemsAnimator.SetInteger(AnimatorParameters.poseIndexHash, (int)CharacterPoseEnum.WorkingAtPCPosesV05);
    }

    private void SetupSessionDelayed()
    {
    }
    
    private void OnDestroy()
    {
        m_LastChapterProgress?.UnregisterObserver(this);
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
        if (m_LastChapterProgress.GetRatio() >= 1f)
        {
            // success!
            TutorialManager.Instance.ShowMessage(MessageEnum.Success);
        }
    }
}
