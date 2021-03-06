using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Difficulty setting parameters
[CreateAssetMenu(fileName = "ActivityData", menuName = "Data/Activity Data", order = 2)]
public class ActivityData : ScriptableObject
{
    [Tooltip("ID of the activity, used to retrieve it in Activity Manager's activities map")]
    public int id = -1;

    [Tooltip("Check this to hide activity on start (for tutorial, testing design iterations, etc.)")]
    public bool lockedOnStart = false;

    [Tooltip("Name of the activity")]
    public string activityName = "Some activity";

    [Tooltip("Description of the activity")]
    public string description = "Do something.";

    [Tooltip("Character pose to show during activity")]
    public CharacterPoseEnum characterPoseEnum = CharacterPoseEnum.Idle;

    [Tooltip("(Optional) SFX to play on activity start")]
    public AudioClip sfx;
}

