using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity6_FeedbackFamily : ActivityBehaviour
{
    public override void Execute()
    {
        float timeSpentRatio = TryAdvanceTimeAndReturnAdvanceRatio(balance.feedbackFamilyTimeAdvance);

        float insightForClarityIncrease = 0f;
        insightForClarityIncrease += balance.feedbackFamilyInsightForClarityIncrease * timeSpentRatio;
        
        float insightForClarityAdvance = AdvanceSessionValue(SessionGameplayValueType.InsightClarity, insightForClarityIncrease);
        Debug.LogFormat("Feedback Family: Insight for Clarity +{0}", insightForClarityAdvance);
    }
}
