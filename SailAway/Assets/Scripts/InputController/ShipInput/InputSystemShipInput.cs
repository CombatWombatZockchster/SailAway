using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class InputSystemShipInput : ShipInput
{
    
    private Vector2 smoothSails = new Vector2(0,0);
    public float sailSmoothing = 25f;
    private Vector2 smoothRudder = new Vector2(0, 0);
    public float rudderSmoothing = 20f;
    private float smoothIntensity = 0f;
    
    private IObservable<Vector2> _sailDirection;
    private IObservable<Vector2> _shipDirection;
    private IObservable<float> _sailIntensity;

    public override IObservable<Vector2> sailDirection
    {
        get { return _sailDirection; }
    }
    public override IObservable<Vector2> shipDirection
    {
        get { return _shipDirection; }
    }
    public override IObservable<float> sailIntensity
    {
        get { return _sailIntensity; }
    }
    
    private MainInput controls;
    
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    protected void Awake()
    {
        controls = new MainInput();
        
        // Hide the mouse cursor and lock it in the game window.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Application.targetFrameRate = 60;

        //Sail direction
        _sailDirection = this.UpdateAsObservable().Select(_ =>
        {
            
            var currentValue = controls.OpenSea.SailDirection.ReadValue<Vector2>();
            smoothSails = new Vector2(
                Mathf.Lerp(smoothSails.x, currentValue.x, sailSmoothing * Time.deltaTime),
                Mathf.Lerp(smoothSails.y, currentValue.y, sailSmoothing * Time.deltaTime));
            return smoothSails;
        });
        
        //Ship direction
        _shipDirection = this.UpdateAsObservable().Select(_ =>
        {
            var currentValue = controls.OpenSea.ShipDirection.ReadValue<Vector2>();
            smoothRudder = new Vector2(
                Mathf.Lerp(smoothRudder.x, currentValue.x, rudderSmoothing * Time.deltaTime),
                Mathf.Lerp(smoothRudder.y, currentValue.y, rudderSmoothing * Time.deltaTime));
            return smoothRudder;
        });
        
        //Sail Intensity
        _sailIntensity = this.UpdateAsObservable().Select(_ =>
        {
            var currentValue =  controls.OpenSea.SailIntensity.ReadValue<float>();
            smoothIntensity = Mathf.Lerp(smoothIntensity, currentValue, 6 * Time.deltaTime);
            return smoothIntensity;
        });

    }
}
