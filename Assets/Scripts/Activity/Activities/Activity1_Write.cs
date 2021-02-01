using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity1_Write : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Write");
        
        m_GameplayValuesContainer.motivation.ChangeValue(-5f);
        m_GameplayValuesContainer.writingProgress.ChangeValue(10f);
    }
}
