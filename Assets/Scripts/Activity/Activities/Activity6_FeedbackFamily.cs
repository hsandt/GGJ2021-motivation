using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity6_FeedbackFamily : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FeedbackFamily");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(5f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(0f);
    }
}
