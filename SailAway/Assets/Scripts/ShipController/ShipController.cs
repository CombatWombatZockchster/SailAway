using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    public static Vector2 windDir = Vector3.forward;
    public static float windStrength = 100.0f;

    Vector2 shipForward = Vector2.up;
    Vector2 sailForward = Vector2.up;//TODO: convert fromlocal to global
    Vector2 rudderForward = Vector2.up;//TODO: might need inverting

    //[Range(0.0f, 1.0f)] float keelStrength = 0.9f;
    //[Range(0.0f, 1.0f)] float sailStrength = 1.0f;
    [SerializeField] float turnSpeed = 10.0f;

    Rigidbody rigid;

    void Start()
    {
        //TODO: listen to input streams

        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        shipForward = vector2FromVector3(transform.forward);

        rigid.AddForce(transform.forward * moveStrength());

        rigid.MoveRotation(rudderRotation());
    }

    Quaternion rudderRotation()
    {
        float rot = transform.rotation.eulerAngles.y;

        rot += turnSpeed * rudderDrag();

        return Quaternion.Euler(0, rot, 0); 
    }

    float rudderDrag()
    {
        return Vector2.SignedAngle(shipForward, rudderForward) / 180.0f;
    }

    public static Vector2 vector2FromVector3(Vector3 v3)
    {
        return new Vector2(v3.x, v3.z);
    }
    public static Vector3 vector3FromVector2(Vector2 v2)
    {
        return new Vector3(v2.x, 0, v2.y);
    }

    float relatieWindStrength()
   {
        return windStrength * Vector2.Angle(windDir, sailForward) / 180.0f;
   }

   float moveStrength()//TODO: use keel strength
   {
        return relatieWindStrength() * (1 - (Vector2.Angle(shipForward, sailForward) / 180.0f));
   }




    void OnDrawGizmos()
    {
        //Wind direction
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + vector3FromVector2(windDir) * windStrength / 10.0f);

        //Forward direction
        Gizmos.color = Color.blue;
        if(rigid != null)
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * rigid.velocity.magnitude);
        else
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2.0f);

        //Sail direction
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + Vector3.up*2, transform.position + Vector3.up*2 + vector3FromVector2(sailForward) * moveStrength() / 10.0f);

        //Rudder direction
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + vector3FromVector2(rudderForward) * (1.0f/10.0f - 2.0f));
    }
}
