using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity9_FreshAir : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("FreshAir");
        
        m_GameplayValuesContainer.motivation.ChangeValue(10f);
        m_GameplayValuesContainer.writingProgress.ChangeValue(10f);
    }
}
