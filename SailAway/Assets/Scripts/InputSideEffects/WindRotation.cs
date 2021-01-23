/*
 *  Wirtten by Jonas
 *  Mostly copied from Felix other signal scripts
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class WindRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject shipObject;
    private IShipSignals _shipSignals;
    private GameObject _flag;
    public bool invertedVector = true;

    Vector3 dir;

    private void Awake()
    {
        _shipSignals = shipObject.GetComponent<ShipController>();
        _flag = gameObject;
    }

    private void Start()
    {
        _shipSignals.windDirection.Subscribe(a =>
        {
            _flag.transform.localRotation = Quaternion.Euler(0f, Vector3.SignedAngle(shipObject.transform.forward, (invertedVector? -1 :1) * a, new Vector3(0, 1, 0)), 0f);
        }).AddTo(this);
        _shipSignals.shiplTiltRelative.Subscribe(_ =>
        {
            _flag.transform.localRotation =
                Quaternion.Euler(0f, Vector3.SignedAngle(shipObject.transform.forward, (invertedVector? -1 :1) * _shipSignals.windDirection.Value, new Vector3(0, 1, 0)), 0f);
        }).AddTo(this);
    }

    
}
