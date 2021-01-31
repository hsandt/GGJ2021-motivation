using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity3_Study : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Study");
        
        m_GameplayValuesContainer.motivation.DecreaseValue(5f);
        m_GameplayValuesContainer.writingProgress.IncreaseValue(10f);
    }
}
