using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Session Gameplay Value Data
[CreateAssetMenu(fileName = "SessionGameplayValueData", menuName = "Data/Session Gameplay Value Data", order = 6)]
public class SessionGameplayValueData : GameplayValueData<SessionGameplayValueType>
{
    public override int TypeIndex => (int) type;
}

