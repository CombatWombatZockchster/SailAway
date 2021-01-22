using System;
using UnityEngine;
using UniRx;

public abstract class ShipInput : MonoBehaviour
{
    /// <summary>
    /// Move axes in WASD / D-Pad style.
    /// Interaction type: continuous axes.
    /// </summary>
    public abstract IObservable<Vector2> sailDirection { get; }
    
    /// <summary>
    /// Jump button.
    /// Interaction type: Trigger.
    /// </summary>
    public abstract IObservable<Unit> shipDirection { get;  }

    /// <summary>
    /// Run button.
    /// Interaction type: Toggle.
    /// </summary>
    /// public abstract ReadOnlyReactiveProperty<bool> run { get; }
    
 
}



