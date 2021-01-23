using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BirdPositioner : MonoBehaviour
{
    public GameObject[] birds;
    public float maxRadius = 100f;
    private float _radius;
    private float _targetRadius;
    public AnimationCurve curve;
    public float speed = 30f;
    public GameObject playerShip;
    
    void FixedUpdate()
    {
        _targetRadius = Vector3.Distance(gameObject.transform.position, playerShip.transform.position);
        _radius = curve.Evaluate(_targetRadius / maxRadius) * maxRadius;
        for (int i = 0; i < birds.Length; i++)
        {
            
            float angle = speed * Time.fixedTime + (360 / birds.Length) * i + i * 3;
            birds[i].transform.localPosition = new Vector3( Mathf.Cos(Mathf.Deg2Rad * angle) * (_radius + i * 3), 2f,
                Mathf.Sin(Mathf.Deg2Rad * angle) * _radius);
            birds[i].transform.localRotation = Quaternion.Euler(0f, 180f - angle, 0f);
        }
    }
}
