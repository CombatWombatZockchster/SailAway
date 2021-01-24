/*
 * Written by Jonas
 * Camera follows the target
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [SerializeField] float height = 5.0f;
    [SerializeField] float distance = 7.0f;
    [SerializeField] float turnSwing = 2.0f;
    [SerializeField] AnimationCurve swingResponse = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
    [SerializeField] float smoothPos = 10.0f; 
    [SerializeField] float smoothRot = 10.0f;

    private IShipSignals _shipSignals;
    float swing = 0.0f;
    float speed = 0.0f;
    [SerializeField] float expectedMaxSpeed = 20.0f;
    void Awake()
    {
        if (target == null) target = GameObject.FindObjectOfType<ShipController>().gameObject.transform;

        _shipSignals = target.GetComponent<ShipController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _shipSignals.rudderAngle.Subscribe(a =>
        {
            swing = a / 90.0f;          
        }).AddTo(this);

        _shipSignals.shipSpeed.Subscribe(a =>
        {
            speed = Mathf.Clamp(a / expectedMaxSpeed, 0.0f, 1.0f);
            speed = swingResponse.Evaluate(speed);
            //Debug.Log(a + ", " + speed);
        }).AddTo(this);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = target.position;
        pos += -target.forward * distance;
        pos += Vector3.up * height;
        pos += turnSwing * swing * speed * target.right;

        transform.position = Vector3.Lerp(transform.position, pos, Mathf.Clamp(smoothPos * Time.deltaTime, 0.0f, 1.0f));


        Quaternion rot = Quaternion.LookRotation(target.position - transform.position, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Mathf.Clamp(smoothRot * Time.deltaTime, 0.0f, 1.0f));
    }
}
