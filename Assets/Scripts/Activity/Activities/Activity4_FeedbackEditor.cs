using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity4_FeedbackEditor : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FeedbackEditor");
        
        m_GameplayValuesContainer.motivation.DecreaseValue(5f);
        m_GameplayValuesContainer.writingProgress.IncreaseValue(10f);
    }
}
