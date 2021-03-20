using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity3_Study : ActivityBehaviour
{
    public override void Execute()
    {
        float physicalHealthProgressMultiplier = GetPhysicalHealthProgressMultiplier();

        float timeSpentRatio = TryAdvanceTimeAndReturnAdvanceRatio(balance.studyTimeAdvance);

        float physicalHealthSpentRatio = TryConsumeSessionValueAndReturnConsumptionRatio(
            SessionGameplayValueType.PhysicalHealth, balance.studyPhysicalHealthConsumption, timeSpentRatio);

        float increase = 0f;
        increase += balance.studyBaseMaterialIncrease * timeSpentRatio;
        increase += balance.studyPhysicalHealthExtraMaterialIncrease * physicalHealthSpentRatio;
        
        increase *= physicalHealthProgressMultiplier;

        float advance = AdvanceSessionValue(SessionGameplayValueType.WritingSkills, increase);
        Debug.LogFormat("Study: Writing Skills +{0}", advance);
    }
}
