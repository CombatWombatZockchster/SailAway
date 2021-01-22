using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using System.Collections.Generic;

public class SailRotation : MonoBehaviour
{
    [SerializeField] 
    private GameObject shipObject;
    private IShipSignals _shipSignals;
    private GameObject _sails;

    private void Awake()
    {
        _shipSignals = shipObject.GetComponent<ShipController>();
        _sails = gameObject;
    }

    private void start()
    {
        _shipSignals.sailAngle.Subscribe(a =>
        {
            _sails.transform.Rotate(0f, a, 0f);
        }).AddTo(this);
    }
}
