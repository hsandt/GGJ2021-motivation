using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity1_Write : ActivityBehaviour
{
    public override void Execute()
    {
        float timeSpent = AdvanceSessionValue(SessionGameplayValueType.Time, balance.writeTimeAdvance);
        float timeSpentRatio = timeSpent / balance.writeTimeAdvance;

        float physicalHealthSpent = ConsumeSessionValue(SessionGameplayValueType.PhysicalHealth, timeSpentRatio * balance.writePhysicalHealthConsumption);

        float increase = 0f;
        increase += balance.writeBaseProgressIncrease * timeSpentRatio;
        increase += balance.writePhysicalHealthExtraProgressIncrease * physicalHealthSpent;
        
        float advance = AdvanceCurrentChapterValue(ChapterGameplayValueType.WritingProgress, increase);
        Debug.LogFormat("Write: Write Progress +{0}", advance);
    }
}
