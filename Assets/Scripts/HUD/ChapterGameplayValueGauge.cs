using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChapterGameplayValueGauge : Gauge<ChapterGameplayValueType>
{
    /* Parameter */

    /// Chapter on which to track gameplay value
    private int chapterIndex;
    
    protected override GameplayValue<ChapterGameplayValueType> GetTrackedGameplayValue()
    {
        return SessionManager.Instance.GameplayValuesContainer.GetChapterGameplayValue(chapterIndex,
            m_TrackedGameplayValueType);
    }
}
