using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SessionGameplayValueGauge : Gauge<SessionGameplayValueType>
{
    protected override GameplayValue<SessionGameplayValueType> GetTrackedGameplayValue()
    {
        return SessionManager.Instance.GameplayValuesContainer.GetSessionGameplayValue(m_TrackedGameplayValueType);
    }
}
