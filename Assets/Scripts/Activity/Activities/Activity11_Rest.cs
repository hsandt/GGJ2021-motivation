using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity11_Rest : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Rest");
        
        m_GameplayValuesContainer.motivation.DecreaseValue(5f);
        m_GameplayValuesContainer.writingProgress.IncreaseValue(10f);
    }
}
