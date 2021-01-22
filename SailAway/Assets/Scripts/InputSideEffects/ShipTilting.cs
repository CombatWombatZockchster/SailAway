using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using System.Collections.Generic;

//Add this script to your ship
public class ShipTilting : MonoBehaviour
{
    private IShipSignals _shipSignals;
    public float maxAngle;

    private void Awake()
    {
        _shipSignals = gameObject.GetComponent<ShipController>();
    }

    private void Start()
    {
        _shipSignals.shiplTiltRelative.Subscribe(a =>
        {
            // gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, a * maxAngle);
        }).AddTo(this);
    }
}
