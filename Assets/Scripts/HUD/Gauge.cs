using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gauge : MonoBehaviour, IGameplayValueObserver
{
    [Header("External references")]

    [Tooltip("Gameplay value represented by the gauge")]
    public GameplayValue trackedGameplayValue;

    
    [Header("Child references")]
    
    [Tooltip("Gauge Fill Rect Transform")]
    public RectTransform fillRectTransform;

    [Tooltip("Value Name Widget")]
    public TextMeshProUGUI valeNameWidget;

    [Tooltip("Value Text Widget")]
    public TextMeshProUGUI valueTextWidget;

    
    private void Awake()
    {
        trackedGameplayValue.RegisterObserver(this);
        valeNameWidget.text = trackedGameplayValue.ValueName;
        
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
        // 25.6 -> "25"
        valueTextWidget.text = trackedGameplayValue.CurrentValue.ToString("0");
        
        fillRectTransform.anchorMax = new Vector2(trackedGameplayValue.GetRatio(), 1f);
    }

    public void NotifyValueChange()
    {
        RefreshGaugeFillSize();
    }
}
