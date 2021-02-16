using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity2_Research : ActivityBehaviour
{
    public override void Execute()
    {
        float timeSpentRatio = TryAdvanceTimeAndReturnAdvanceRatio(balance.researchTimeAdvance);

        float physicalHealthSpentRatio = TryConsumeSessionValueAndReturnConsumptionRatio(
            SessionGameplayValueType.PhysicalHealth, balance.researchPhysicalHealthConsumption, timeSpentRatio);

        float increase = 0f;
        increase += balance.researchBaseMaterialIncrease * timeSpentRatio;
        increase += balance.researchPhysicalHealthExtraMaterialIncrease * physicalHealthSpentRatio;
        
        float advance = AdvanceSessionValue(SessionGameplayValueType.ResearchMaterial, increase);
        Debug.LogFormat("Research: Research Material +{0}", advance);
    }
}
