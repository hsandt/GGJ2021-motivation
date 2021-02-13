using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity3_Study : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Study");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(5f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(0f);
    }
}
