using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity11_Rest : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Rest");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(20f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(0f);
    }
}
