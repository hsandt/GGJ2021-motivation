using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity8_Garbage : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Garbage");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(15f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(0f);
    }
}
