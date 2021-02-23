using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity1_Write : ActivityBehaviour
{
    public override void Execute()
    {
        float physicalHealthProgressMultiplier = GetPhysicalHealthProgressMultiplier();

        float timeSpentRatio = TryAdvanceTimeAndReturnAdvanceRatio(balance.writeTimeAdvance);

        float physicalHealthSpentRatio = TryConsumeSessionValueAndReturnConsumptionRatio(
            SessionGameplayValueType.PhysicalHealth, balance.writePhysicalHealthConsumption, timeSpentRatio);

        float researchMaterialSpentRatio = TryConsumeSessionValueAndReturnConsumptionRatio(
            SessionGameplayValueType.ResearchMaterial, balance.writeResearchMaterialConsumption, timeSpentRatio);

        float increase = 0f;
        increase += balance.writeBaseProgressIncrease * timeSpentRatio;
        increase += balance.writePhysicalHealthExtraProgressIncrease * physicalHealthSpentRatio;
        increase += balance.writeResearchMaterialExtraProgressIncrease * researchMaterialSpentRatio;
        
        increase *= physicalHealthProgressMultiplier;
        
        float advance = AdvanceCurrentChapterValue(ChapterGameplayValueType.WritingProgress, increase);
        Debug.LogFormat("Write: Write Progress +{0}", advance);
    }
}
