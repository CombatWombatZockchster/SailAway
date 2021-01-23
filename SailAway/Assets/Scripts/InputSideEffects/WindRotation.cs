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

    Vector3 dir;

    private void Awake()
    {
        _shipSignals = shipObject.GetComponent<ShipController>();
    }

    private void Start()
    {
        _shipSignals.windDirection.Subscribe(v3 =>
        {
            dir = -v3;
        }).AddTo(this);
    }

    void Update()
    {
        transform.LookAt(transform.position + dir, Vector3.up);
    }
}
