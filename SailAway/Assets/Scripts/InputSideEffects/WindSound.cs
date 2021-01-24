using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[RequireComponent(typeof(AudioSource))]
public class WindSound : MonoBehaviour
{
    [SerializeField][Range(0.0f, 1.0f)] float minVolume = 0.1f;
    [SerializeField] [Range(0.0f, 1.0f)] float maxVolume = 1.0f;

    AudioSource source;

    [SerializeField] float expectedMaxSpeed = 20.0f;

    IShipSignals signal;
    [SerializeField] GameObject ship;

    void Awake()
    {
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
                source.volume = Mathf.Clamp(a / expectedMaxSpeed, minVolume, maxVolume);
            }
        ).AddTo(this);
    }
}
