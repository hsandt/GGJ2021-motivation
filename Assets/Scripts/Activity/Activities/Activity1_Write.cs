using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity1_Write : ActivityBehaviour
{
    public override void Execute()
    {        
        // required resources
        float power = 0f;
        power += balance.writeTimePowerFactor * AdvanceSessionValue(SessionGameplayValueType.Time, balance.writeTimeAdvance);
        power += balance.writePhysicalHealthPowerFactor * ConsumeSessionValue(SessionGameplayValueType.PhysicalHealth, balance.writePhysicalHealthConsumption);
        
        float advance = AdvanceCurrentChapterValue(ChapterGameplayValueType.WritingProgress, power);
        Debug.LogFormat("Write: +{0}", advance);
    }
}
