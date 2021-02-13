using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity2_Research : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Research");
        
        ChangeSessionGameplayValue(SessionGameplayValueType.Time, 10f);
        ChangeSessionGameplayValue(SessionGameplayValueType.PhysicalHealth, -5f);
        ChangeSessionGameplayValue(SessionGameplayValueType.ResearchMaterial, 5f);
    }
}
