using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity10_SmartphoneLeisure : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("SmartphoneLeisure");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(5f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(0f);
    }
}
