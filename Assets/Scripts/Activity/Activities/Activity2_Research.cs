using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity2_Research : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Research");
        
        AdvanceSessionValue(SessionGameplayValueType.Time, 10f);
        AdvanceSessionValue(SessionGameplayValueType.PhysicalHealth, -5f);
        AdvanceSessionValue(SessionGameplayValueType.ResearchMaterial, 5f);
    }
}
