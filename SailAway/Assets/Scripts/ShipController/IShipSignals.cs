using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public interface IShipSignals
{
    ReactiveProperty<float> sailAngle { get; }
    ReactiveProperty<float> rudderAngle { get; }
    ReactiveProperty<float> shiplTiltRelative { get; }//[-1,1]
    ReactiveProperty<float> shipSpeed{ get; }
}
