using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity6_FeedbackFamily : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FeedbackFamily");
        
        m_GameplayValuesContainer.motivation.ChangeValue(5f);
        m_GameplayValuesContainer.writingProgress.ChangeValue(0f);
    }
}
