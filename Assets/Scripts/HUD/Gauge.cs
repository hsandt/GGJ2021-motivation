using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Gauge<TGameplayValueType> : MonoBehaviour, IGameplayValueObserver
{
    [Header("External references")]
    
    // Tracked gameplay value, deducated from m_TrackedGameplayValueType, with accessor defined in child class
    protected GameplayValue<TGameplayValueType> m_TrackedGameplayValue;

    
    [Header("Child references")]
    
    [Tooltip("Value Name Widget")]
    public TextMeshProUGUI valueNameWidget;

    [Tooltip("Value Text Widget")]
    public TextMeshProUGUI valueTextWidget;

    
    [Header("Parameters")]
    
    [Tooltip("Should the value be represented as a percentage? (with % symbol)")]
    public bool isPercentage = false;

    
    private void OnDestroy()
    {
        m_TrackedGameplayValue?.UnregisterObserver(this);
    }

    public void SetTrackedGameplayValue(GameplayValue<TGameplayValueType> gameplayValue)
    {
        m_TrackedGameplayValue = gameplayValue;
        m_TrackedGameplayValue.RegisterObserver(this);
        valueNameWidget.text = m_TrackedGameplayValue.Data.valueName;
        
        // refresh immediately as we have missed the first value change GameplayValuesContainer.CreateGameplayValueArrays
        RefreshGaugeFillSize();
    }

    protected virtual void RefreshGaugeFillSize()
    {
        // 25.6 -> "25"
        string valueText = m_TrackedGameplayValue.CurrentValue.ToString("0");
        if (isPercentage)
        {
            valueText += "%";
        }
        else
        {
            valueText += $"/{m_TrackedGameplayValue.MaxValue}";
        }
        valueTextWidget.text = valueText;
    }

    public void NotifyValueChange()
    {
        RefreshGaugeFillSize();
    }
}
