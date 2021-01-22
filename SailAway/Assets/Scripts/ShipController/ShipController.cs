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
using UniRx;


[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    public static Vector2 windDir = Vector2.up;
    public static float windStrength = 5.0f;

    Vector2 shipForward = Vector2.up;
    Vector2 sailForward = Vector2.up;//TODO: convert fromlocal to global
    Vector2 rudderForward = -Vector2.up;//TODO: might need inverting

    Vector2 worldSailForward = Vector2.up;//TODO: convert fromlocal to global
    Vector2 worldRudderForward = -Vector2.up;//TODO: might need inverting

    [Range(0.0f, 1.0f)] float sailStrength = 1.0f;

    [SerializeField][Range(0.0f, 1.0f)] float keelStrength = 0.9f;
    [SerializeField] float turnSpeed = 10.0f;
    [SerializeField] float speed = 10.0f;

    Rigidbody rigid;


    public ShipInput input; 


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
                    sailForward = input /*vector2FromVector3(transform.TransformDirection(vector3FromVector2(input))).normalized*/;
                }
            )
            .AddTo(this);

        input.shipDirection
            .Subscribe
            (
                input =>
                {
                    if (input == Vector2.zero)
                        rudderForward = Vector2.up;
                    else
                        rudderForward = -input /*vector2FromVector3(transform.TransformDirection(vector3FromVector2(input))).normalized*/;
                }
            )
            .AddTo(this);
        
        input.sailIntensity
            .Where(v => v != null)
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
    }

    Quaternion rudderRotation()
    {
        float rot = transform.rotation.eulerAngles.y;

        rot += turnSpeed * rudderDrag();

        return Quaternion.Euler(0, rot, 0); 
    }

    float rudderDrag()
    {
        return Vector2.SignedAngle(shipForward, worldRudderForward) / 180.0f * Mathf.Clamp(rigid.velocity.magnitude/speed/2.0f,0.0f,1.0f);
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
        return windStrength * Vector2.Dot(windDir.normalized, worldSailForward.normalized);/*Vector2.Angle(windDir, sailForward) / 180.0f*/
    }

   float moveStrength()//TODO: use keel strength
   {
        float windShipMul = Vector2.Dot(shipForward.normalized, worldSailForward.normalized);//(1 - (Vector2.Angle(shipForward, sailForward) / 180.0f)
        return sailStrength * speed * relativeWindStrength() * windShipMul;
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
