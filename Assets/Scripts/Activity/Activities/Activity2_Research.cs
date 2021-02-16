using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity2_Research : ActivityBehaviour
{
    public override void Execute()
    {
        float timeSpent = AdvanceSessionValue(SessionGameplayValueType.Time, balance.researchTimeAdvance);
        float timeSpentRatio = timeSpent / balance.researchTimeAdvance;

        float physicalHealthSpent = ConsumeSessionValue(SessionGameplayValueType.PhysicalHealth, timeSpentRatio * balance.researchPhysicalHealthConsumption);

        float increase = 0f;
        increase += balance.researchBaseMaterialIncrease * timeSpentRatio;
        increase += balance.researchPhysicalHealthExtraMaterialIncrease * physicalHealthSpent;
        
        float advance = AdvanceSessionValue(SessionGameplayValueType.ResearchMaterial, increase);
        Debug.LogFormat("Research: Research Material +{0}", advance);
    }
}
