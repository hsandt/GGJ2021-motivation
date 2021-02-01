using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Dynamic audio parameters
[CreateAssetMenu(fileName = "DynamicAudioParameters", menuName = "Data/Dynamic Audio Parameters", order = 4)]
public class DynamicAudioParameters : ScriptableObject
{
    [Tooltip("Motivation ratio must be greater than or equal to this value to play high motivation BGM")]
    public float highMotivationThresholdRatio = 0.5f;
}

