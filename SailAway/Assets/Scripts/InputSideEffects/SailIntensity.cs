using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SailIntensity : MonoBehaviour
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

    private void Start()
    {
        _shipSignals.sailIntensity.Subscribe(a =>
        {
            _sails.transform.localScale = new Vector3(1f, Mathf.Clamp(a, 0.2f, 1f), 1f);
        }).AddTo(this);
    }
}
