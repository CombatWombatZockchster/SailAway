/*
 * Written by Jonas
 * higher fov when fast for game feel
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[RequireComponent(typeof(Camera))]
public class FOVSpeed : MonoBehaviour
{
    Camera cam;
    IShipSignals shipSignals;
    [SerializeField] GameObject ship;
    float baseFOV;
    [SerializeField] float fastFOVBoost = 10.0f;
    [SerializeField] AnimationCurve speedResponse = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
    [SerializeField] float expectedMaxSpeed = 20.0f;
    float lv = 0;
    

    void Awake()
    {
        if (ship == null) ship = GameObject.FindObjectOfType<ShipController>().gameObject;

        shipSignals = ship.GetComponent<ShipController>();
    }
    
    void Start()
    {
        cam = GetComponent<Camera>();
        baseFOV = cam.fieldOfView;

        shipSignals.shipSpeed.Subscribe
        (
            s =>
            {
                lv = s / expectedMaxSpeed;
                lv = speedResponse.Evaluate(lv);
                cam.fieldOfView = Mathf.Lerp(baseFOV, baseFOV + fastFOVBoost, lv);
            }
        ).AddTo(this);
    }
}
