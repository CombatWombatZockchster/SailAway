using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx;
using UniRx.Triggers;

public class InputSystemMenuInput : MenuInput
{
    
    
    private ReadOnlyReactiveProperty<bool> _start;
    private ReadOnlyReactiveProperty<bool> _help;

    
    public override ReadOnlyReactiveProperty<bool> start
    {
        get { return _start; }
    }
    
    public override ReadOnlyReactiveProperty<bool> help
    {
        get { return _help; }
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
        _start = this.UpdateAsObservable().Select(_ => controls.MenuNavigation.Start.ReadValueAsObject() != null)
            .ToReadOnlyReactiveProperty();
        _help = this.UpdateAsObservable().Select(_ => controls.MenuNavigation.Help.ReadValueAsObject() != null)
            .ToReadOnlyReactiveProperty();
    }
}
