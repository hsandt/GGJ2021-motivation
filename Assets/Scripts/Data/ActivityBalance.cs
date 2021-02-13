using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Activity game balance parameters
[CreateAssetMenu(fileName = "ActivityBalance", menuName = "Data/Activity Balance", order = 8)]
public class ActivityBalance : ScriptableObject
{
    [Header("Write")]
    
    [Tooltip("Base progress of Write")]
    public float writeIncreaseBase = 10f;
    
    [Tooltip("Time spent by Write")]
    public float writeTimeAdvance = 20f;
    
    [Tooltip("How much spending Time helps Write progress")]
    public float writeTimeIncreaseFactor = 0.5f;
    
    [Tooltip("Physical Health lost by Write")]
    public float writePhysicalHealthConsumption = 5f;
    
    [Tooltip("How much losing Physical Health helps Write progress")]
    public float writePhysicalHealthIncreaseFactor = 1f;
}
