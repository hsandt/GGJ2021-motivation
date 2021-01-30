using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Difficulty setting parameters
[CreateAssetMenu(fileName = "DifficultySetting", menuName = "Data/Difficulty Setting", order = 2)]
public class DifficultySetting : ScriptableObject
{

    [Tooltip("Initial value for Writing Progress")]
    public float initialWritingProgress = 0f;

    [Tooltip("Max value for Writing Progress")]
    public float maxWritingProgress = 100f;

    [Tooltip("Initial value for Motivation")]
    public float initialMotivation = 50f;

    [Tooltip("Max value for Motivation")]
    public float maxMotivation = 100f;

}

