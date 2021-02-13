using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity11_Rest : ActivityBehaviour
{
    public override void Execute()
    {
        Debug.Log("Rest");
        
        ChangeSessionGameplayValue(SessionGameplayValueType.PhysicalHealth, 20f);
    }
}
