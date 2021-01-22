using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public interface IShipSignals
{
    IObservable<float> sailAngle { get; }
    IObservable<float> rudderlAngle { get; }
    IObservable<float> shiplTiltRelative { get; }//[-1,1]
    IObservable<float> speed{ get; }
}
