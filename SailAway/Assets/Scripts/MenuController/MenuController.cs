using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class MenuController : MonoBehaviour
{
    private bool _inHelpScreen = false;
    public MenuInput input;

    public Camera camera;

    public Vector3 cameraPosHelpScreen;

    private Vector3 _cameraPosStartScreen;
    public Canvas start;
    public Canvas help;
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraPosStartScreen = camera.transform.position;
        help.enabled = false;
        input.help.Subscribe(a =>
        {
            if (a)
                changeScreen();
        }).AddTo(this);
        input.start.Subscribe(a =>
        {
            if (a)
                startGame();
        }).AddTo(this);
    }

    private void changeScreen()
    {
        if (_inHelpScreen)
        {
            camera.transform.position = _cameraPosStartScreen;
            start.enabled = true;
            help.enabled = false;
            _inHelpScreen = false;
        }
        else
        {
            camera.transform.position = cameraPosHelpScreen;
            start.enabled = false;
            help.enabled = true;
            _inHelpScreen = true;
        }
    }

    private void startGame()
    {
        Debug.Log("Start Game");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
