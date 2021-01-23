using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPositioner : MonoBehaviour
{
    public GameObject[] birds;
    public float radius = 10f;
    public float speed = (2*Mathf.PI)/5;
    void Start()
    {
        
        for (int i = 0; i < birds.Length; i++)
        {
            birds[i].transform.localPosition = new Vector3( Mathf.Cos(Mathf.Deg2Rad *(360 / birds.Length) * i) * radius, 1f,
                 Mathf.Sin(Mathf.Deg2Rad *(360 / birds.Length) * i)* radius);
        }
    }
    void FixedUpdate()
    {
        for (int i = 0; i < birds.Length; i++)
        {
            float angle = speed * Time.fixedTime + (360 / birds.Length) * i;
            birds[i].transform.localPosition = new Vector3( Mathf.Cos(Mathf.Deg2Rad * angle) * radius, 1f,
                Mathf.Sin(Mathf.Deg2Rad * angle) * radius);
            birds[i].transform.localRotation = Quaternion.Euler(0f, 180f - angle, 0f);
        }
    }
}
