using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class InputSystemShipInput : ShipInput
{
    private IObservable<Vector2> _sailDirection;
    private IObservable<Vector2> _shipDirection;
    private IObservable<bool> _sailIntensity;

    public override IObservable<Vector2> sailDirection
    {
        get { return _sailDirection; }
    }
    public override IObservable<Vector2> shipDirection
    {
        get { return _shipDirection; }
    }
    public override IObservable<bool> sailIntensity
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
            return controls.OpenSea.SailDirection.ReadValue<Vector2>();
        });
        
        //Ship direction
        _shipDirection = this.UpdateAsObservable().Select(_ =>
        {
            return controls.OpenSea.ShipDirection.ReadValue<Vector2>();
        });
        
        //Sail Intensity
        _sailIntensity = this.UpdateAsObservable().Select(_ =>
        {
            return controls.OpenSea.SailIntensity.ReadValue<bool>();
        });

    }
}
