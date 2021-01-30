using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour, IGameplayValueObserver
{
    [Header("External references")]

    [Tooltip("Gameplay value represented by the gauge")]
    public GameplayValue trackedGameplayValue;

    
    [Header("Child references")]
    
    [Tooltip("Gauge Fill Rect Transform")]
    public RectTransform fillRectTransform;

    
    private void Awake()
    {
        trackedGameplayValue.RegisterObserver(this);
        RefreshGaugeFillSize();
    }

    private void OnDestroy()
    {
        if (trackedGameplayValue)
        {
            trackedGameplayValue.UnregisterObserver(this);
        }
    }

    private void RefreshGaugeFillSize()
    {
        fillRectTransform.anchorMax = new Vector2(trackedGameplayValue.GetRatio(), 1f);
    }

    public void NotifyValueChange()
    {
        RefreshGaugeFillSize();
    }
}
