using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity7_Drink : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Drink");
        
        m_GameplayValuesContainer.GetSessionGameplayValue(SessionGameplayValueType.PhysicalHealth).ChangeValue(10f);
    }
}
