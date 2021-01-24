using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRotator : MonoBehaviour
{
    [SerializeField] ShipController ship;

    Collectible[] collectibles;
    
    [SerializeField] [Range(0.0f, 1.0f)] float useForwardOrTarget = 0.5f;
    [SerializeField] float changeSpeed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        updateCollectibles();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (closestTarget() - ship.transform.position).normalized;
        dir = Vector3.Lerp(ship.transform.forward, dir, useForwardOrTarget).normalized;
        ship.setWindDirection(Vector3.Lerp(ShipController.vector3FromVector2(ShipController.windDir).normalized, dir, changeSpeed * Time.deltaTime));
    }

    Vector3 closestTarget()
    {
        Vector3 closest = new Vector3(0,0,0);
        float minDis = float.MaxValue;

        for(int i = 0; i < collectibles.Length; i++)
        {
            Collectible c = collectibles[i];
            
            if(c == null)
            {
                updateCollectibles();
                return closestTarget();
            }

            float dis = Vector3.Distance(ship.transform.position, c.transform.position);

            if(dis < minDis)
            {
                minDis = dis;
                closest = c.transform.position;
            }
        }

        return closest;
    }

    void updateCollectibles()
    {
        collectibles = GameObject.FindObjectsOfType<Collectible>();
    }

    void OnDrawGizmos()
    {
        if (collectibles == null) return;

        Gizmos.color = Color.black;
        for (int i = 0; i < collectibles.Length; i++)
        {
            Gizmos.DrawSphere(collectibles[i].transform.position, 1.0f);
            Gizmos.DrawLine(collectibles[i].transform.position, transform.position);
        }

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(closestTarget(), 1.0f);
        Gizmos.DrawLine(closestTarget(), transform.position);       
    }
}
