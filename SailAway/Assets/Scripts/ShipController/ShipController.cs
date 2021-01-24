/*
 * Written by Jonas
 * Applies semi realistic physics to the boat based on the input
 * 
 * TODO:
 * Mehr freirum fpr ausrichtung gegen wimd
 * dreh geschwindigkeit reltiv zu geschwindigkeit
*/
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using System.Security.Cryptography.X509Certificates;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour, IShipSignals
{
    Rigidbody rigid;

    public static Vector2 windDir = Vector2.up;
    public static float windStrength = 5.0f;

    Vector2 shipForward = Vector2.up;
    Vector2 sailForward = Vector2.up;
    Vector2 rudderForward = -Vector2.up;

    Vector2 worldSailForward = Vector2.up;
    Vector2 worldRudderForward = -Vector2.up;

    [Range(0.0f, 1.0f)] float sailStrength = 1.0f;

    [SerializeField][Range(0.0f, 1.0f)] float keelStrength = 0.9f;
    [SerializeField] float turnSpeed = 10.0f;
    [SerializeField][Range(0.0f, 1.0f)] float minRudderDrag = 0.15f;
    [SerializeField] float speed = 10.0f;

    [SerializeField] float maxSailAngle = 90.0f;
    [SerializeField] float maxRudderAngle = 90.0f;

    public ShipInput input;

    #region signals
    private ReactiveProperty<float> _sailAngle = new ReactiveProperty<float>(0.0f);
    private ReactiveProperty<float> _rudderAngle = new ReactiveProperty<float>(0.0f);
    private ReactiveProperty<float> _shiplTiltRelative = new ReactiveProperty<float>(0.0f);
    private ReactiveProperty<float> _shipSpeed = new ReactiveProperty<float>(0.0f);
    private ReactiveProperty<float> _sailIntesity = new ReactiveProperty<float>(0.0f);
    private ReactiveProperty<Vector3> _windDirection = new ReactiveProperty<Vector3>(vector3FromVector2(windDir));

    public ReactiveProperty<float> sailAngle => _sailAngle;
    public ReactiveProperty<float> rudderAngle => _rudderAngle;
    public ReactiveProperty<float> shiplTiltRelative => _shiplTiltRelative;
    public ReactiveProperty<float> shipSpeed => _shipSpeed;
    public ReactiveProperty<float> sailIntensity => _sailIntesity;
    public ReactiveProperty<Vector3> windDirection => _windDirection;
   
    public void setWindDirection(Vector3 v3)
    {
        Vector2 v2 = vector2FromVector3(v3);
        windDir = v2;
        _windDirection.Value = v3;
    }
    
    #endregion

    void Awake()
    {
        /*
       _sailAngle = new ReactiveProperty<float>(0.0f);
       _rudderAngle = new ReactiveProperty<float>(0.0f);
       _shiplTiltRelative = new ReactiveProperty<float>(0.0f);
       _shipSpeed = new ReactiveProperty<float>(0.0f);
       */
    }
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

#region input
        //listen to input
        input.sailDirection
            .Where(v => v != Vector2.zero)
            .Subscribe
            (
                input =>
                {
                    
                    float angle = Vector2.SignedAngle(Vector2.up, input);
                    if (Mathf.Abs(angle) <= maxSailAngle)
                        sailForward = input;
                    else
                    {
                        Vector2 v = new Vector2
                        (
                            (angle > 0 ? -1.0f : 1.0f) * Mathf.Sin(Mathf.Deg2Rad*maxSailAngle), 
                            -Mathf.Cos(Mathf.Deg2Rad*maxSailAngle)
                        );

                        sailForward = v;
                    }
                    

                    //sailForward = new Vector2(input.x, Mathf.Abs(input.y));
                }
            )
            .AddTo(this);

        input.shipDirection
            .Subscribe
            (
                input =>
                {
                    /*
                    if (input == Vector2.zero)
                        rudderForward = -Vector2.up;
                    else
                    {
                        float angle = Vector2.SignedAngle(-Vector2.up, input);
                        if (Mathf.Abs(angle) <= maxRudderAngle)
                            rudderForward = input;
                        else
                        {
                            Vector2 v = new Vector2
                            (
                                (angle > 0 ? 1.0f : -1.0f) * Mathf.Sin(Mathf.Deg2Rad*maxRudderAngle),
                                -Mathf.Cos(Mathf.Deg2Rad*maxRudderAngle)
                            );

                            rudderForward = v;
                        }
                    }
                    */
                    float lerpV = input.x / 2.0f + 0.5f;
                    float angle = Mathf.Lerp(-maxRudderAngle, maxRudderAngle, lerpV);

                    Vector2 v = new Vector2
                            (
                                Mathf.Sin(Mathf.Deg2Rad * angle),
                                -Mathf.Cos(Mathf.Deg2Rad * angle)
                            );

                    rudderForward = v;

                }
            )
            .AddTo(this);
        
        input.sailIntensity
            .Subscribe
            (
                input =>
                {
                    sailStrength = 1.0f-input;
                }
            )
            .AddTo(this);
        
#endregion
    }

    void FixedUpdate()
    {
        shipForward = vector2FromVector3(transform.forward);
        worldSailForward = vector2FromVector3(transform.TransformDirection(vector3FromVector2(sailForward))).normalized;
        worldRudderForward = vector2FromVector3(transform.TransformDirection(vector3FromVector2(rudderForward))).normalized;

        rigid.AddForce(transform.forward * moveStrength());

        rigid.MoveRotation(rudderRotation());

        rigid.velocity = Vector3.Lerp(rigid.velocity, rigid.velocity.magnitude * transform.forward, keelStrength);

        
        _sailAngle.Value = Vector2.SignedAngle(Vector2.up, sailForward);
        _rudderAngle.Value = Vector2.SignedAngle(-Vector2.up, rudderForward);
        _shiplTiltRelative.Value = Mathf.Sin(Mathf.Deg2Rad * Vector2.SignedAngle(shipForward, windDir)) * sailStrength;
        _shipSpeed.Value = rigid.velocity.magnitude;
        _sailIntesity.Value = sailStrength;
    }

    Quaternion rudderRotation()
    {
        float rot = transform.rotation.eulerAngles.y;
        rot += turnSpeed * rudderDrag();
        return Quaternion.Euler(0, rot, 0);        
    }

    float rudderDrag()
    {
        float f = Vector2.SignedAngle(-Vector2.up, rudderForward) / 180.0f * Mathf.Clamp(rigid.velocity.magnitude / speed, 0.0f, 1.0f);
        float a = Mathf.Clamp(Mathf.Abs(f), minRudderDrag, 1.0f);
        float v = rudderForward.x;
        if (v != 0)
        {
            v /= Mathf.Abs(rudderForward.x);
            return v * a;
        }
        else return 0;
    }

    public static Vector2 vector2FromVector3(Vector3 v3)
    {
        return new Vector2(v3.x, v3.z);
    }
    public static Vector3 vector3FromVector2(Vector2 v2)
    {
        return new Vector3(v2.x, 0, v2.y);
    }

    float relativeWindStrength()
    {
        return windStrength * Vector2.Dot(windDir.normalized, worldSailForward.normalized);
    }

   float moveStrength()
   {
        float windShipMul = (Vector2.Dot(shipForward.normalized, windDir.normalized)/5) + 0.8f;//(1 - (Vector2.Angle(shipForward, sailForward) / 180.0f
        //Debug.Log(windShipMul);
        return sailStrength * speed * relativeWindStrength() * Mathf.Clamp(windShipMul, 0.8f, 1.0f);
   }




    void OnDrawGizmos()
    {
        //Wind direction
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + vector3FromVector2(windDir) * windStrength);

        //Forward direction
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 3.0f);

        //Sail direction
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + Vector3.up*2, transform.position + Vector3.up*2 + vector3FromVector2(worldSailForward) * 3.0f);

        //Rudder direction
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position - transform.forward * 2.0f, transform.position + vector3FromVector2(worldRudderForward) - transform.forward*2.0f);
    }
}
