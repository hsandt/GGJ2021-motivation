using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity2_Research : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Research");
        
        AdvanceSessionGameplayValue(SessionGameplayValueType.Time, 10f);
        AdvanceSessionGameplayValue(SessionGameplayValueType.PhysicalHealth, -5f);
        AdvanceSessionGameplayValue(SessionGameplayValueType.ResearchMaterial, 5f);
    }
}
