using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;
using CommonsPattern;

public class AudioManager : SingletonManager<AudioManager>, IGameplayValueObserver
{
    [Header("External references")]
    
    [Tooltip("BGM when motivation is high")]
    public AudioClip bgmMotivationHigh;
    
    [Tooltip("BGM when motivation is low")]
    public AudioClip bgmMotivationLow;
    
    
    [Header("Children references")]

    [Tooltip("Audio Source for BGM")]
    public AudioSource bgmAudioSource;
    
    [Tooltip("Audio Source for SFX")]
    public AudioSource sfxAudioSource;
    
    
    /* Cached external references */

    private GameplayValuesContainer m_GameplayValuesContainer;
    
    
    /* Cached data references */
    
    private DynamicAudioParameters m_DynamicAudioParameters;


    protected override void Init()
    {        
        m_DynamicAudioParameters = ResourcesUtil.LoadOrFail<DynamicAudioParameters>("Audio/DynamicAudioParameters");
    }

    private void Start()
    {
        // copy cached reference already set on SessionManager (at Awake time)
        m_GameplayValuesContainer = SessionManager.Instance.GameplayValuesContainer;
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).RegisterObserver(this);
        
        // we need to play the bgm manually once since we are registering after the initial value setting and
        // NotifyValueChange won't be called until the next change of Physical Health
        PlayBgmMatchingMotivation();
    }
    
    private void OnDestroy()
    {
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth)?.UnregisterObserver(this);
    }

    public void PlayBgm(AudioClip bgm)
    {
        if (bgmAudioSource.clip != bgm)
        {
            bgmAudioSource.clip = bgm;
            bgmAudioSource.Play();
        }
    }

    public void PlaySFX(AudioClip sfx)
    {
        // stop any previous SFX (otherwise they can overlap)
        sfxAudioSource.Stop();
        sfxAudioSource.PlayOneShot(sfx);
    }

    public void NotifyValueChange()
    {
        PlayBgmMatchingMotivation();
    }
    
    private void PlayBgmMatchingMotivation()
    {
        if (m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).GetRatio() < m_DynamicAudioParameters.highMotivationThresholdRatio)
        {
            PlayBgm(bgmMotivationLow);
        }
        else
        {
            PlayBgm(bgmMotivationHigh);
        }
    }
}
