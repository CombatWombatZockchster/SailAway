using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class MenuInput : MonoBehaviour
{
    /// <summary>
    /// Start button.
    /// Interaction type: Trigger.
    /// </summary>
    public abstract ReadOnlyReactiveProperty<bool> start { get; }
    
    /// <summary>
    /// help button.
    /// Interaction type: Trigger.
    /// </summary>
    public abstract ReadOnlyReactiveProperty<bool> help { get; }

    
}
