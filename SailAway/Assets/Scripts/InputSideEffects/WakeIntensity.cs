using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class WakeIntensity : MonoBehaviour
{
    [SerializeField] private GameObject shipObject;
    private IShipSignals _shipSignals;
    [SerializeField] float maxSpeed = 15.0f;

    private void Awake()
    {
        _shipSignals = shipObject.GetComponent<ShipController>();
    }

    private void Start()
    {
        _shipSignals.shipSpeed.Subscribe(a =>
        {
            float b = Mathf.Clamp(a / maxSpeed, 0.0f, 1.0f);
            transform.localScale = new Vector3(b, b, b);
        }).AddTo(this);
    }
}
