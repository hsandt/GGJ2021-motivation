using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Difficulty setting parameters
[CreateAssetMenu(fileName = "TutorialData", menuName = "Data/Tutorial Data", order = 5)]
public class TutorialData : ScriptableObject
{
    [Tooltip("Tutorial messages, indexed by step index")]
    public TutorialMessage[] tutorialMessages;
}

