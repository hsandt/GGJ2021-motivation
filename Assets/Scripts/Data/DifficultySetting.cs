using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Difficulty setting parameters
[CreateAssetMenu(fileName = "DifficultySetting", menuName = "Data/Difficulty Setting", order = 2)]
public class DifficultySetting : ScriptableObject {

    [Tooltip("Initial value for Writing Progress")]
    public float m_InitialWritingProgress = 0f;

    [Tooltip("Max value for Writing Progress")]
    public float m_MaxWritingProgress = 100f;

    [Tooltip("Initial value for Motivation")]
    public float m_InitialMotivation = 50f;

    [Tooltip("Max value for Motivation")]
    public float m_MaxMotivation = 100f;

}

