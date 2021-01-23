using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using UniRx;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ReactiveProperty<int> counter = new ReactiveProperty<int>(0);

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            IncrementCounter();
            Debug.Log("Du hast " + counter + " Kiste(n) gesammelt");
            DestroyGameObject();
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