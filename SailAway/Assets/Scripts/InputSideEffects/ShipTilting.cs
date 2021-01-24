using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using System.Collections.Generic;

//Add this script to your ship
public class ShipTilting : MonoBehaviour
{
    [SerializeField] 
    private GameObject shipObject;
    private IShipSignals _shipSignals;
    public float maxAngle;
    private GameObject _body;

    private void Awake()
    {
        if (shipObject == null) shipObject = GameObject.FindObjectOfType<ShipController>().gameObject;

        _shipSignals = shipObject.GetComponent<ShipController>();
        _body = gameObject;
    }

    private void Start()
    {
        _shipSignals.shiplTiltRelative.Subscribe(a =>
        {
            _body.transform.localRotation = Quaternion.Euler(0f, 0f, a * maxAngle);
        }).AddTo(this);
    }
}
