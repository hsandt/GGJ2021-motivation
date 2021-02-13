using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity1_Write : ActivityBehaviour
{
    public override void Execute()
    {        
        // required resources
        float writingPower = 0f;
        writingPower += AdvanceSessionGameplayValue(SessionGameplayValueType.Time, 20f);
        writingPower += ConsumeSessionGameplayValue(SessionGameplayValueType.PhysicalHealth, 5f);
        
        float advance = AdvanceCurrentChapterGameplayValue(ChapterGameplayValueType.WritingProgress, writingPower);
        Debug.LogFormat("Write: +{0}", advance);
    }
}
