using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using System.Collections.Generic;

//Add this script to your ship
public class NewBehaviourScript : MonoBehaviour
{
    private IShipSignals _shipSignals;
    public float maxAngle;

    private void Awake()
    {
        _shipSignals = gameObject.GetComponent<ShipController>();
    }

    private void start()
    {
        _shipSignals.shiplTiltRelative.Subscribe(a =>
        {
            gameObject.transform.Rotate(0f, 0f, a * maxAngle);
        }).AddTo(this);
    }
}
