using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity4_FeedbackEditor : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FeedbackEditor");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(-10f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(0f);
    }
}
