using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity9_FreshAir : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FreshAir");
        
        m_GameplayValuesContainer.motivation.DecreaseValue(5f);
        m_GameplayValuesContainer.writingProgress.IncreaseValue(10f);
    }
}
