using System;
using UnityEngine;
using UniRx;

public abstract class ShipInput : MonoBehaviour
{
    /// <summary>
    /// change direction of sails
    /// Interaction type: continuous axes.
    /// </summary>
    public abstract IObservable<Vector2> sailDirection { get; }
    
    /// <summary>
    /// change direction of ship
    /// Interaction type: continuous axes.
    /// </summary>
    public abstract IObservable<Unit> shipDirection { get;  }
    
}



