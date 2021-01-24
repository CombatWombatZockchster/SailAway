using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEditor.U2D;

[RequireComponent(typeof(AudioSource))]
public class WindSound : MonoBehaviour
{
    [SerializeField] AnimationCurve speedResponse = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
    [SerializeField] float expectedMaxSpeed = 20.0f;

    AudioSource source;

    IShipSignals signal;
    [SerializeField] GameObject ship;

    void Awake()
    {
        if (ship == null) ship = GameObject.FindObjectOfType<ShipController>().gameObject;


        signal = ship.GetComponent<ShipController>();
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        signal.shipSpeed.Subscribe
        (
            a =>
            {
                source.volume = speedResponse.Evaluate(a / expectedMaxSpeed);
            }
        ).AddTo(this);
    }
}
