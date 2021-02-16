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
    
    [Tooltip("Base Write Progress gain when doing full Write")]
    public float writeBaseProgressIncrease = 10f;
    
    [Tooltip("Physical Health loss when doing full Write")]
    public float writePhysicalHealthConsumption = 5f;
    
    [Tooltip("Additional Write Progress gain when fully consuming Physical Health")]
    public float writePhysicalHealthExtraProgressIncrease = 1f;
    
    
    [Header("Research")]
    
    [Tooltip("Time spent by Research")]
    public float researchTimeAdvance = 20f;
    
    [Tooltip("Base Research Material gain when doing full Research")]
    public float researchBaseMaterialIncrease = 10f;
    
    [Tooltip("Physical Health loss when doing full Research")]
    public float researchPhysicalHealthConsumption = 5f;
    
    [Tooltip("Additional Research Material gain when fully consuming Physical Health")]
    public float researchPhysicalHealthExtraMaterialIncrease = 1f;
    
    
    [Header("Rest")]
    
    [Tooltip("Time spent by Rest")]
    public float restTimeAdvance = 20f;
    
    [Tooltip("Physical Health health gain when doing full Rest")]
    public float restPhysicalHealthIncrease = 20f;
   
    [Tooltip("Mental Health health gain when doing full Rest")]
    public float restMentalHealthIncrease = 5f;
}
