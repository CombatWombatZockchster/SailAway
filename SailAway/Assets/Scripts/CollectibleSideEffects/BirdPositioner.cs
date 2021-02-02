using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BirdPositioner : MonoBehaviour
{
    public GameObject[] birds;
    public float minRadius = 0.5f;
    public float maxRadius = 4f;
    private float maxNoise;
    private float _radius;
    private float _targetRadius;
    public AnimationCurve curve;
    public float speed = 6f;
    public GameObject playerShip;
    
    void Start()
    {
        if (playerShip == null) playerShip = GameObject.FindObjectOfType<ShipController>().gameObject;
    }

    void FixedUpdate()
    {
        Vector3 target = new Vector3(playerShip.transform.position.x, 0, playerShip.transform.position.z);
        Vector3 central = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        _targetRadius = Vector3.Distance(target, central)/10f;
        _radius = Mathf.Lerp(_radius, Mathf.Clamp(_targetRadius, minRadius, maxRadius), 0.5f);
        var size = ((_radius - minRadius) / (maxRadius - minRadius)) * 8 + 2;
        for (int i = 0; i < birds.Length; i++)
        {
            float angleSpeed = speed / _radius;
            // float noise = Mathf.PerlinNoise(birds[i].transform.position.x, birds[i].transform.position.y) * minRadius/2f;
            float noise = 0f;
            float angle = angleSpeed * Time.fixedTime + (360 / birds.Length) * i + noise;
            birds[i].transform.localPosition = new Vector3( Mathf.Cos(Mathf.Deg2Rad * angle) * -_radius, 2f,
                Mathf.Sin(Mathf.Deg2Rad * angle) * _radius);
            birds[i].transform.localRotation = Quaternion.Euler(0f, angle, 0f);
            birds[i].transform.localScale = new Vector3(size, size, size);
        }
    }
}
