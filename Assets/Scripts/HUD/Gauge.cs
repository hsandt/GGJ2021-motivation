using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Gauge<TGameplayValueType> : MonoBehaviour, IGameplayValueObserver
{
    [Header("External references")]

    [SerializeField, Tooltip("Type of gameplay value represented by the gauge")]
    protected TGameplayValueType m_TrackedGameplayValueType;
    
    // Tracked gameplay value, deducated from m_TrackedGameplayValueType, with accessor defined in child class
    private GameplayValue<TGameplayValueType> m_TrackedGameplayValue;

    
    [Header("Child references")]
    
    [Tooltip("Gauge Fill Rect Transform")]
    public RectTransform fillRectTransform;

    [Tooltip("Value Name Widget")]
    public TextMeshProUGUI valueNameWidget;

    [Tooltip("Value Text Widget")]
    public TextMeshProUGUI valueTextWidget;

    
    [Header("Parameters")]
    
    [Tooltip("Should the value be represented as a percentage? (with % symbol)")]
    public bool isPercentage = false;


    protected abstract GameplayValue<TGameplayValueType> GetTrackedGameplayValue();
    
    private void Start()
    {
        // get tracked gameplay value on Start, as they are now constructed on Awake via SessionManager.Init
        m_TrackedGameplayValue = GetTrackedGameplayValue();
        
        m_TrackedGameplayValue.RegisterObserver(this);
        valueNameWidget.text = m_TrackedGameplayValue.Data.valueName;
        
        // refresh immediately as we have missed the first value change GameplayValuesContainer.CreateGameplayValueArrays
        RefreshGaugeFillSize();
    }

    private void OnDestroy()
    {
        m_TrackedGameplayValue?.UnregisterObserver(this);
    }

    private void RefreshGaugeFillSize()
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
        
        // Old code was moving anchor, but now we should use the Rect Mask 2D component width
        // to have a rectangle edge. However this uses a px width so we must calculate value from ratio. 
        fillRectTransform.anchorMax = new Vector2(m_TrackedGameplayValue.GetRatio(), 1f);
    }

    public void NotifyValueChange()
    {
        RefreshGaugeFillSize();
    }
}
