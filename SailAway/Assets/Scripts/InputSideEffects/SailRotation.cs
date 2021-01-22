using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using System.Collections.Generic;

//Add this script to the sails of your boat
public class SailRotation : MonoBehaviour
{
    // [SerializeField] 
    // private GameObject shipObject;
    private IShipSignals _shipSignals;
    private GameObject _sails;

    private void Awake()
    {
        _shipSignals = transform.parent.GetComponent<ShipController>();
        _sails = gameObject;
        
    }

    private void Start()
    {
        _shipSignals.sailAngle.Subscribe(a =>
        {
            _sails.transform.localRotation = Quaternion.Euler(0f, -a, 0f);
        }).AddTo(this);
    }
}
