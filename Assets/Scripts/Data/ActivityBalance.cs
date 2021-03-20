using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Activity game balance parameters
[CreateAssetMenu(fileName = "ActivityBalance", menuName = "Data/Activity Balance", order = 8)]
public class ActivityBalance : ScriptableObject
{
    [Header("Common")]
    
    [Tooltip("Threshold under which Physical Health is considered Low (threshold is included in Low range)")]
    public float physicalHealthLowThreshold = 15f;

    [Tooltip("When in Low Physical Health, this penalty factor is applied to non-resting activities' output resources")]
    public float lowPhysicalHealthProgressPenaltyFactor = 0.5f;

    
    [Header("Write")]
    
    [Tooltip("Time spent by Write")]
    public float writeTimeAdvance = 1f;
    
    [Tooltip("Base Write Progress gain when doing full Write")]
    public float writeBaseProgressIncrease = 10f;
    
    [Tooltip("Physical Health standard consumption when doing full Write")]
    public float writePhysicalHealthConsumption = 5f;
    
    [Tooltip("Additional Write Progress gain when consuming standard amount of Physical Health")]
    public float writePhysicalHealthExtraProgressIncrease = 5f;
    
    [Tooltip("Research Material standard consumption when doing full Write")]
    public float writeResearchMaterialConsumption = 10f;
    
    [Tooltip("Additional Write Progress gain when consuming standard amount of Research Material")]
    public float writeResearchMaterialExtraProgressIncrease = 10f;
    
    [Tooltip("Additional Write Progress gain per skill unit")]
    public float writeSkillExtraProgressIncreaseFactor = 1f;
    
    [Tooltip("Base Clarity gain when doing full Write")]
    public float writeBaseClarityIncrease = 5f;

    [Tooltip("Additional Clarity gain per skill unit")]
    public float writeSkillExtraClarityIncreaseFactor = 1f;
    
    [Tooltip("Insight for Clarity standard consumption when doing full Write")]
    public float writeInsightForClarityConsumption = 10f;
    
    [Tooltip("Additional Clarity gain when consuming standard amount of Insight for Clarity")]
    public float writeInsightForClarityExtraClarityIncrease = 1f;
    
    
    [Header("Research")]
    
    [Tooltip("Time spent by Research")]
    public float researchTimeAdvance = 1f;
    
    [Tooltip("Base Research Material gain when doing full Research")]
    public float researchBaseMaterialIncrease = 10f;
    
    [Tooltip("Physical Health loss when doing full Research")]
    public float researchPhysicalHealthConsumption = 5f;
    
    [Tooltip("Additional Research Material gain when fully consuming Physical Health")]
    public float researchPhysicalHealthExtraMaterialIncrease = 5f;
    
    
    [Header("Study")]
    
    [Tooltip("Time spent by Study")]
    public float studyTimeAdvance = 1f;
    
    [Tooltip("Base Study Material gain when doing full Study")]
    public float studyBaseMaterialIncrease = 5f;
    
    [Tooltip("Physical Health loss when doing full Study")]
    public float studyPhysicalHealthConsumption = 5f;
    
    [Tooltip("Additional Study Material gain when fully consuming Physical Health")]
    public float studyPhysicalHealthExtraMaterialIncrease = 5f;
    
    
    [Header("Feedback Family")]
    
    [Tooltip("Time spent by Feedback Family")]
    public float feedbackFamilyTimeAdvance = 1f;
    
    [Tooltip("Insight for Clarity gain when doing full Feedback Family")]
    public float feedbackFamilyInsightForClarityIncrease = 5f;
    
    
    [Header("Rest")]
    
    [Tooltip("Time spent by Rest")]
    public float restTimeAdvance = 1f;
    
    [Tooltip("Physical Health health gain when doing full Rest")]
    public float restPhysicalHealthIncrease = 20f;
   
    [Tooltip("Mental Health health gain when doing full Rest")]
    public float restMentalHealthIncrease = 5f;
}
