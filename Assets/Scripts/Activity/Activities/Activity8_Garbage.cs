using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity8_Garbage : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Garbage");
        
        m_GameplayValuesContainer.motivation.ChangeValue(15f);
        m_GameplayValuesContainer.writingProgress.ChangeValue(0f);
    }
}
