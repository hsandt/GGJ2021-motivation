using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity10_SmartphoneLeisure : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("SmartphoneLeisure");
        
        m_GameplayValuesContainer.motivation.ChangeValue(5f);
        m_GameplayValuesContainer.writingProgress.ChangeValue(0f);
    }
}
