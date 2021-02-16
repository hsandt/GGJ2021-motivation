using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity11_Rest : ActivityBehaviour
{
    public override void Execute()
    {
        float timeSpent = AdvanceSessionValue(SessionGameplayValueType.Time, balance.restTimeAdvance);
        float timeSpentRatio = timeSpent / balance.restTimeAdvance;

        float physicalHealthIncrease = balance.restPhysicalHealthIncrease * timeSpentRatio;
        float mentalHealthIncrease = balance.restMentalHealthIncrease * timeSpentRatio;
        
        float physicalHealthAdvance = AdvanceSessionValue(SessionGameplayValueType.PhysicalHealth, physicalHealthIncrease);
        float mentalHealthAdvance = AdvanceSessionValue(SessionGameplayValueType.MentalHealth, mentalHealthIncrease);
        Debug.LogFormat("Rest: PhysicalHealth +{0}, Mental Health +{1}", physicalHealthAdvance, mentalHealthAdvance);
    }
}
