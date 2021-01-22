using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ship")
        {
            Debug.Log("Du hast nen Obstacle getroffen noob"); 
            
        }
        
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
