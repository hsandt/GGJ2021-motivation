using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity8_Garbage : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Garbage");
        
        m_GameplayValuesContainer.motivation.DecreaseValue(5f);
        m_GameplayValuesContainer.writingProgress.IncreaseValue(10f);
    }
}
