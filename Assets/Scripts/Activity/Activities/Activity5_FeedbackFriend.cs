using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity5_FeedbackFriend : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FeedbackFriend");
        
        m_GameplayValuesContainer.motivation.ChangeValue(5f);
        m_GameplayValuesContainer.writingProgress.ChangeValue(10f);
    }
}
