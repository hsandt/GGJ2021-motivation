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

        float writingIncrease = 0f;
        writingIncrease += balance.writeBaseProgressIncrease * timeSpentRatio;
        writingIncrease += balance.writePhysicalHealthExtraProgressIncrease * physicalHealthSpentRatio;
        writingIncrease += balance.writeResearchMaterialExtraProgressIncrease * researchMaterialSpentRatio;
        writingIncrease += balance.writeSkillExtraProgressIncreaseFactor * GetSessionValue(SessionGameplayValueType.WritingSkills);
        
        writingIncrease *= physicalHealthProgressMultiplier;
        
        float writingAdvance = AdvanceCurrentChapterValue(ChapterGameplayValueType.WritingProgress, writingIncrease);
        Debug.LogFormat("Write: Write Progress +{0}", writingAdvance);
        
        float clarityIncrease = 0f;
        clarityIncrease += balance.writeBaseClarityIncrease * timeSpentRatio;
        clarityIncrease += balance.writeSkillExtraClarityIncreaseFactor * GetSessionValue(SessionGameplayValueType.WritingSkills);
        
        clarityIncrease *= physicalHealthProgressMultiplier;
        
        float clarityAdvance = AdvanceCurrentChapterValue(ChapterGameplayValueType.Clarity, clarityIncrease);
        Debug.LogFormat("Write: Clarity +{0}", clarityAdvance);
    }
}
