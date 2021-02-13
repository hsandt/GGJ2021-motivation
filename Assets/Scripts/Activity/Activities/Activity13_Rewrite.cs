using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity13_Rewrite : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Rewrite");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(20f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(0f);
    }
}
