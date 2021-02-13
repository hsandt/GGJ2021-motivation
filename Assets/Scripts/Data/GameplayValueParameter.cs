using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameplayValueParameter
{
    [Tooltip("Initial value for gameplay value")]
    public float initialValue = 0f;
        
    [Tooltip("Max value for gameplay value")]
    public float maxValue = 100f;
}
