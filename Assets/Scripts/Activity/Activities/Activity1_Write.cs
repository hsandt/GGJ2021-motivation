using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity1_Write : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Write");
        
        ChangeSessionGameplayValue(SessionGameplayValueType.Time, 5f);
        ChangeSessionGameplayValue(SessionGameplayValueType.PhysicalHealth, -5f);
        ChangeCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress, 5f);
    }
}
