using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;

/// Responsible for registering abstract gauge to session gameplay value (composition over inheritance)
public class SessionGameplayValueGaugeBinder : MonoBehaviour
{
    /* Sibling components */

    private Gauge<SessionGameplayValueType> m_Gauge;
    
    
    /* Parameter */

    [SerializeField, Tooltip("Type of session gameplay value represented")]
    protected SessionGameplayValueType m_SessionGameplayValueType;
    
    private void Awake()
    {
        m_Gauge = this.GetComponentOrFail<Gauge<SessionGameplayValueType>>();
    }
    
    private void Start ()
    {
        // get tracked gameplay value on Start, as they are now constructed on Awake via SessionManager.Init
        var sessionGameplayValue = SessionManager.Instance.GameplayValuesContainer.GetSessionGameplayValue(m_SessionGameplayValueType);
        m_Gauge.SetTrackedGameplayValue(sessionGameplayValue);
    }
}
