using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity5_FeedbackFriend : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FeedbackFriend");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(5f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(10f);
    }
}
