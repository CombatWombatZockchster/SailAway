using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private bool _inAnimation = false;
    public MenuInput input;
    public float time = 5;

    public Camera camera;

    public Vector3 cameraPosHelpScreen;
    public Vector3 cameraPosWinScreen;
    public Quaternion cameraRotWinScreen;
    public Vector3 cameraPosLoseScreen;
    public Quaternion cameraRotLoseScreen;
    private Quaternion _cameraRotHelpScreen = quaternion.Euler(0f, 0f, 0f);
    private Vector3 _cameraPosStartScreen;
    private Quaternion _cameraRotStartScreen;
    public Canvas start;
    public Canvas help;
    public Canvas win;
    public Canvas lose;
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraPosStartScreen = camera.transform.position;
        _cameraRotStartScreen = camera.transform.rotation;
        help.enabled = false;
        win.enabled = false;
        lose.enabled = false;
        if (StaticGameState.gameState == 1)
        {
            start.enabled = false;
            win.enabled = true;
            camera.transform.position = cameraPosWinScreen;
            camera.transform.rotation = cameraRotWinScreen;
        } else if (StaticGameState.gameState == 2)
        {
            start.enabled = false;
            lose.enabled = true;
            camera.transform.position = cameraPosLoseScreen;
            camera.transform.rotation = cameraRotLoseScreen;
        }
        
        input.help.Subscribe(a =>
        {
            if (a && !_inAnimation && StaticGameState.gameState == 0)
            {
                StartCoroutine(changeScreen(camera.transform.position, camera.transform.rotation, cameraPosHelpScreen,
                    _cameraRotHelpScreen, help));
                StaticGameState.gameState = 3;
            }else if (a && !_inAnimation && StaticGameState.gameState == 3)
            {
                StartCoroutine(changeScreen(camera.transform.position, camera.transform.rotation, _cameraPosStartScreen,
                    _cameraRotStartScreen, start));
                StaticGameState.startScreen();
                
            }
        }).AddTo(this);
        
        input.start.Subscribe(a =>
        {
            
            if (a && !_inAnimation)
            {
                if (StaticGameState.gameState == 0)
                    startGame();
                else if (StaticGameState.gameState == 1 || StaticGameState.gameState == 2)
                {
                    Debug.Log(StaticGameState.gameState);
                    StartCoroutine(changeScreen(camera.transform.position, camera.transform.rotation, _cameraPosStartScreen,
                        _cameraRotStartScreen, start));
                    StaticGameState.startScreen();
                    
                }
            }
            
                
        }).AddTo(this);
        
    }
    
    
    
    private IEnumerator changeScreen(Vector3 fromPos, Quaternion fromRot, Vector3 toPos, Quaternion toRot, Canvas toEnable)
    {
        
        _inAnimation = true;
        help.enabled = false;
        win.enabled = false;
        lose.enabled = false;
        start.enabled = false;
        float elapsedTime = 0f;
        while (elapsedTime < time)
        {
            camera.transform.position = Vector3.Lerp(fromPos, toPos,
                (elapsedTime/time));
            camera.transform.rotation = Quaternion.Lerp(fromRot, toRot,
                (elapsedTime/time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _inAnimation = false;
        toEnable.enabled = true;
    }

    private void startGame()
    {
        SceneManager.LoadScene(1);

    }
    
}
