using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity4_FeedbackEditor : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FeedbackEditor");
        
        m_GameplayValuesContainer.motivation.ChangeValue(-10f);
        m_GameplayValuesContainer.writingProgress.ChangeValue(0f);
    }
}
