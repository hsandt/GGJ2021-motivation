using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;

/// Responsible for registering abstract gauge to chapter gameplay value (composition over inheritance)
public class ChapterGameplayValueGaugeBinder : MonoBehaviour
{
    /* Sibling components */

    private Gauge<ChapterGameplayValueType> m_Gauge;
    
    
    /* Parameter */

    [SerializeField, Tooltip("Chapter on which to track gameplay value")]
    private int chapterIndex;
    
    [SerializeField, Tooltip("Type of chapter gameplay value represented")]
    protected ChapterGameplayValueType m_ChapterGameplayValueType;
    
    private void Awake()
    {
        m_Gauge = this.GetComponentOrFail<Gauge<ChapterGameplayValueType>>();
    }
    
    private void Start ()
    {
        // get tracked gameplay value on Start, as they are now constructed on Awake via SessionManager.Init
        var chapterGameplayValue = SessionManager.Instance.GameplayValuesContainer.GetChapterGameplayValue(chapterIndex,
            m_ChapterGameplayValueType);
        m_Gauge.SetTrackedGameplayValue(chapterGameplayValue);
    }
}
