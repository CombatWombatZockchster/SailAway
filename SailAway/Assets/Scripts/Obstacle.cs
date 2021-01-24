using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] AudioClip lightHit;
    [SerializeField] AudioClip hardHit;
    [SerializeField] float hardHitSpeed = 5.0f;
    [SerializeField] float lightVolume = 3.0f;
    [SerializeField] float hardVolume = 1.0f;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ship")
        {
            Debug.Log("Du hast nen Obstacle getroffen noob");

            
            Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();
            {
                //Vector3 dir = (transform.position - collision.transform.position).normalized;
                float relativeSpeed = collision.relativeVelocity.magnitude;//Vector3.Project(rigid.velocity, dir).magnitude;
                Debug.Log("Relative Speed: " + relativeSpeed);
                
                if(relativeSpeed >= hardHitSpeed)
                {
                    source.PlayOneShot(hardHit, Mathf.Clamp(hardVolume, 0.0f, 1.0f));
                    //TODO: End game
                }
                else
                {
                    float volume = Mathf.Clamp(relativeSpeed / hardHitSpeed * lightVolume, 0.0f, 1.0f);
                    source.PlayOneShot(lightHit, volume);
                }
            }
        }
        
    }
}
