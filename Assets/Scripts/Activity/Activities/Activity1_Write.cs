using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity1_Write : ActivityBehaviour
{
    public override void Execute()
    {
        float increase = balance.writeIncreaseBase;

        float timeSpent = AdvanceSessionValue(SessionGameplayValueType.Time, balance.writeTimeAdvance);
        float timeSpentRatio = timeSpent / balance.writeTimeAdvance;

        float physicalHealthSpent = ConsumeSessionValue(SessionGameplayValueType.PhysicalHealth, timeSpentRatio * balance.writePhysicalHealthConsumption);
        increase += balance.writePhysicalHealthIncreaseFactor * physicalHealthSpent;

        increase += balance.writeTimeIncreaseFactor * timeSpent;
        increase += balance.writePhysicalHealthIncreaseFactor * physicalHealthSpent;
        
        float advance = AdvanceCurrentChapterValue(ChapterGameplayValueType.WritingProgress, increase);
        Debug.LogFormat("Write: +{0}", advance);
    }
}
