using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Chapter Gameplay Value Data
[CreateAssetMenu(fileName = "ChapterGameplayValueData", menuName = "Data/Chapter Gameplay Value Data", order = 7)]
public class ChapterGameplayValueData : GameplayValueData<ChapterGameplayValueType>
{
    public override int TypeIndex => (int) type;
}

