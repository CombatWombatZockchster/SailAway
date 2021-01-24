using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
using Unity.Mathematics;

public class MenuController : MonoBehaviour
{
    private bool _inHelpScreen = false;
    private bool inAnimation = false;
    public MenuInput input;
    public float time = 5;

    public Camera camera;

    public Vector3 cameraPosHelpScreen;
    private Quaternion _cameraRotHelpScreen = quaternion.Euler(0f, 0f, 0f);
    private Vector3 _cameraPosStartScreen;
    private Quaternion _cameraRotStartScreen;
    public Canvas start;
    public Canvas help;
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraPosStartScreen = camera.transform.position;
        _cameraRotStartScreen = camera.transform.rotation;
        help.enabled = false;
        input.help.Subscribe(a =>
        {
            if (a && !inAnimation)
                StartCoroutine(changeScreen());
        }).AddTo(this);
        input.start.Subscribe(a =>
        {
            if (a && !inAnimation)
                startGame();
        }).AddTo(this);
    }

    private IEnumerator changeScreen()
    {
        if (_inHelpScreen)
        {
            inAnimation = true;
            help.enabled = false;
            _inHelpScreen = false;
            float elapsedTime = 0f;
            while (elapsedTime < time)
            {
                camera.transform.position = Vector3.Lerp(cameraPosHelpScreen, _cameraPosStartScreen,
                    (elapsedTime/time));
                camera.transform.rotation = Quaternion.Lerp(_cameraRotHelpScreen, _cameraRotStartScreen,
                    (elapsedTime/time));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            start.enabled = true;
            inAnimation = false;
        }
        else
        {
            inAnimation = true;
            _inHelpScreen = true;
            start.enabled = false;
            float elapsedTime = 0f;
            while (elapsedTime < time)
            {
                camera.transform.position = Vector3.Lerp(_cameraPosStartScreen, cameraPosHelpScreen,
                    (elapsedTime/time));
                camera.transform.rotation = Quaternion.Lerp(_cameraRotStartScreen,_cameraRotHelpScreen, 
                    (elapsedTime/time));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            help.enabled = true;
            inAnimation = false;
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
