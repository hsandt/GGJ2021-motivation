using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity12_ReadComics : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Read Comics");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(20f);
        SessionManager.Instance.GetCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress).ChangeValue(0f);
    }
}
