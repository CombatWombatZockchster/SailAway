using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SailIntensity : MonoBehaviour
{
    [SerializeField] private GameObject shipObject;
    private IShipSignals _shipSignals;
    [SerializeField] SkinnedMeshRenderer sRenderer;

    private void Awake()
    {
        _shipSignals = shipObject.GetComponent<ShipController>();
    }

    private void Start()
    {
        _shipSignals.sailIntensity.Subscribe(a =>
        {
            //_sails.transform.localScale = new Vector3(1f, Mathf.Clamp(a, 0.2f, 1f), 1f);
            sRenderer.SetBlendShapeWeight(0, (1.0f-a) * 100.0f);
        }).AddTo(this);
    }
}
