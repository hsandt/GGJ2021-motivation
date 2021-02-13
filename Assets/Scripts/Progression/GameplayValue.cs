using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameplayValue<TGameplayValueType>
{
    /// Informative data (doesn't depend on dificulty)
    private GameplayValueData<TGameplayValueType> m_data;
    public GameplayValueData<TGameplayValueType> Data => m_data;

    
    /* Parameters set by Session Manager */
    
    /// Max value
    private float m_MaxValue;
    
    
    /* State */

    /// Current value
    private float m_CurrentValue;
    public float CurrentValue => m_CurrentValue;


    /// List of observers
    private List<IGameplayValueObserver> m_Observers = new List<IGameplayValueObserver>();

    
    public void Init(GameplayValueData<TGameplayValueType> data, int difficultyLevel)
    {
        m_data = data;

        GameplayValueParameter parameter = data.parameterPerDifficultyLevel[difficultyLevel];
        m_MaxValue = parameter.maxValue;
        SetValue(parameter.initialValue);
    }
    
    public void SetValue(float value)
    {
        m_CurrentValue = Mathf.Clamp(value, 0f, m_MaxValue);
        NotifyValueChangeToObservers();
    }
    
    public void ChangeValue(float deltaValue)
    {
        // pass negative deltaValue to decrease
        SetValue(m_CurrentValue + deltaValue);
    }
    
    /// Advance session value and return actual advance (clamped via ChangeValue if value reached max)
    public float AdvanceValue(float deltaValue)
    {
        float oldValue = m_CurrentValue;
        ChangeValue(deltaValue);
        return m_CurrentValue - oldValue;
    }

    /// Consume value and return actual consumption (clamped via ChangeValue if value reached 0)
    public float ConsumeValue(float consumptionValue)
    {
        float oldValue = m_CurrentValue;
        ChangeValue(- consumptionValue);
        return oldValue - m_CurrentValue;
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
