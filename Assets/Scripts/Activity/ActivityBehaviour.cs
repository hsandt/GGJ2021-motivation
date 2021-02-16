using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public abstract class ActivityBehaviour : MonoBehaviour
{
    [Header("Data")]
    
    [Tooltip("Activity ID")]
    public ActivityData data;
    
    
    /* Cached external references */

    protected GameplayValuesContainer m_GameplayValuesContainer;
    protected ActivityBalance balance;

    /// Advance session value and return actual advance (clamped if value reached max)
    protected float AdvanceSessionValue(SessionGameplayValueType type, float deltaValue)
    {
        return SessionManager.Instance.GetSessionGameplayValue(type).AdvanceValue(deltaValue);
    }

    /// Consume session value and return actual consumption (clamped if value reached 0)
    protected float ConsumeSessionValue(SessionGameplayValueType type, float consumptionValue)
    {
        return SessionManager.Instance.GetSessionGameplayValue(type).ConsumeValue(consumptionValue);
    }

    /// Advance chapter value and return actual advance (clamped if value reached max)
    protected float AdvanceCurrentChapterValue(ChapterGameplayValueType type, float deltaValue)
    {
        return SessionManager.Instance.GetCurrentChapterGameplayValue(type).AdvanceValue(deltaValue);
    }
    
    /// Consume current chapter value and return actual consumption (clamped if value reached 0)
    protected float ConsumeCurrentChapterValue(ChapterGameplayValueType type, float deltaValue)
    {
        return SessionManager.Instance.GetCurrentChapterGameplayValue(type).ConsumeValue(deltaValue);
    }
    
    /// Try to advance time by standard duration,
    /// and return the ratio of actual time spent / standard duration
    protected float TryAdvanceTimeAndReturnAdvanceRatio(float standardDuration)
    {
        float timeSpent = AdvanceSessionValue(SessionGameplayValueType.Time, standardDuration);
        float timeSpentRatio = timeSpent / standardDuration;
        return timeSpentRatio;
    }
    
    /// Try to consume standard amount of session gameplay value [type], with the passed time ratio,
    /// and return the ratio of actual consumption / standard amount
    protected float TryConsumeSessionValueAndReturnConsumptionRatio(SessionGameplayValueType type, float standardAmount, float timeSpentRatio)
    {
        float valueSpent = ConsumeSessionValue(type, timeSpentRatio * standardAmount);
        float valueSpentRatio = valueSpent / standardAmount;
        return valueSpentRatio;
    }
    
    private void Start()
    {
        // copy cached reference already set on SessionManager (at Awake time)
        m_GameplayValuesContainer = SessionManager.Instance.GameplayValuesContainer;
        balance = SessionManager.Instance.activityBalance;
    }

    public abstract void Execute();
}
