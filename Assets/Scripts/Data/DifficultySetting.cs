using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Difficulty setting parameters
[CreateAssetMenu(fileName = "DifficultySetting", menuName = "Data/Difficulty Setting", order = 3)]
public class DifficultySetting : ScriptableObject
{
    [Tooltip("Difficulty level, from 0. Used as index to determine which parameter to use for each Gameplay Value Data.")]
    public int level = 0;
    
    [Tooltip("Number of chapters required to complete the novel")]
    public int chaptersCount = 1;
}
