using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public static ReactiveProperty<int> counter = new ReactiveProperty<int>(0);

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            IncrementCounter();
            Debug.Log("Du hast " + counter + " Kiste(n) gesammelt");
            DestroyGameObject();
        }

        if (counter.Value == 6)
        {
            StaticGameState.winGame();
            SceneManager.LoadScene(0);
        }
    }

    public void IncrementCounter()
    {
        counter.Value++;
    }


    void DestroyGameObject()
    {
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}