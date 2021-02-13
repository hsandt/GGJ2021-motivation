using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Activity game balance parameters
[CreateAssetMenu(fileName = "ActivityBalance", menuName = "Data/Activity Balance", order = 8)]
public class ActivityBalance : ScriptableObject
{
    [Header("Write")]
    
    [Tooltip("Time spent by Write")]
    public float writeTimeAdvance = 20f;
    
    [Tooltip("How much spending Time helps Write progress")]
    public float writeTimePowerFactor = 1f;
    
    [Tooltip("Physical Health lost by Write")]
    public float writePhysicalHealthConsumption = 5f;
    
    [Tooltip("How much losing Physical Health helps Write progress")]
    public float writePhysicalHealthPowerFactor = 1f;
}
