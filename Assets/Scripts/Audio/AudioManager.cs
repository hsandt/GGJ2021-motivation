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
        m_GameplayValuesContainer.motivation.RegisterObserver(this);
    }
    
    private void OnDestroy()
    {
        if (m_GameplayValuesContainer.motivation)
        {
            m_GameplayValuesContainer.motivation.UnregisterObserver(this);
        }
    }

    public void PlayBGM(AudioClip bgm)
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
        if (m_GameplayValuesContainer.motivation.GetRatio() < m_DynamicAudioParameters.highMotivationThresholdRatio)
        {
            PlayBGM(bgmMotivationLow);
        }
        else
        {
            PlayBGM(bgmMotivationHigh);
        }
    }
}
