using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Gameplay Value Data
public abstract class GameplayValueData<TGameplayValueType> : ScriptableObject
{
    [Tooltip("Type of value")]
    public TGameplayValueType type;

    /// Return type as integer index (abstraction required as convertible-to-int constraint does not exist)
    public abstract int TypeIndex { get; }

    [Tooltip("Readable name of value")]
    public string valueName = "Gameplay value";

    [Tooltip("Description of the value's role")]
    public string description = "Represents something.";

    [Tooltip("Gameplay value parameter, per difficulty level index")]
    public GameplayValueParameter[] parameterPerDifficultyLevel = new GameplayValueParameter[1];
}
