using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity9_FreshAir : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FreshAir");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(10f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(10f);
    }
}
