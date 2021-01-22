using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class RudderRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private GameObject shipObject;
    private IShipSignals _shipSignals;
    private GameObject _rudder;

    private void Awake()
    {
        _shipSignals = shipObject.GetComponent<ShipController>();
        _rudder = gameObject;
    }

    private void Start()
    {
        _shipSignals.rudderAngle.Subscribe(a =>
        {
            _rudder.transform.localRotation = Quaternion.Euler(0f, -a, 0f);
        }).AddTo(this);
    }
}
