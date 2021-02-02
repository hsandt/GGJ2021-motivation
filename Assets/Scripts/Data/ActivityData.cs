using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Difficulty setting parameters
[CreateAssetMenu(fileName = "ActivityData", menuName = "Data/Activity Data", order = 2)]
public class ActivityData : ScriptableObject
{

    [Tooltip("ID of the activity, used to retrieve it in Activity Manager's activities map")]
    public int id = -1;

    [Tooltip("Name of the activity")]
    public string activityName = "Some activity";

    [Tooltip("Description of the activity")]
    public string description = "Do something.";

    [Tooltip("Character pose to show during activity")]
    public CharacterPoseEnum characterPoseEnum = CharacterPoseEnum.Idle;

}

