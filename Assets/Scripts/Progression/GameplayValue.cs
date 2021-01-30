using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayValue : MonoBehaviour
{
    [Header("Parameters")]

    [SerializeField, Tooltip("Readable name")]
    private string m_ValueName = "Value name";
    public string ValueName => m_ValueName;

    
    /* Parameters set by Session Manager */
    
    /// Max value
    private float m_MaxValue;
    
    
    /* State */

    /// Current value
    private float m_CurrentValue;
    public float CurrentValue => m_CurrentValue;

    /// List of observers
    private List<IGameplayValueObserver> m_Observers = new List<IGameplayValueObserver>();

    
    public void Init(float maxValue, float initialValue)
    {
        m_MaxValue = maxValue;
        SetValue(initialValue);
    }
    
    public void SetValue(float value)
    {
        m_CurrentValue = Mathf.Clamp(value, 0f, m_MaxValue);
        NotifyValueChangeToObservers();
    }
    
    public float GetRatio()
    {
        return m_MaxValue > 0f ? m_CurrentValue / m_MaxValue : 1f;
    }

    public void RegisterObserver(IGameplayValueObserver observer)
    {
        if (!m_Observers.Contains(observer))
        {
            m_Observers.Add(observer);
        }
    }
    
    public void UnregisterObserver(IGameplayValueObserver observer)
    {
        if (m_Observers.Contains(observer))
        {
            m_Observers.Remove(observer);
        }
    }

    private void NotifyValueChangeToObservers()
    {
        foreach (IGameplayValueObserver observer in m_Observers)
        {
            observer.NotifyValueChange();
        }
    }
}
