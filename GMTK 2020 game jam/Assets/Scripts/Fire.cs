using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public ParticleSystem fire;
    public ParticleSystem extinguisher;
    public List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.lossyScale.x < Vector3.one.x * 0.1f && transform.lossyScale.y < Vector3.one.y * 0.1f)
        {
            Destroy(gameObject);
        }
        
        /*
         * if particle collision
         *      grow size
         */
        
    }

    void OnParticleCollision(GameObject other)
    {
        int numFireCollisionEvents = fire.GetCollisionEvents(other, collisionEvents);
        int numExtinguisherCollisionEvents = extinguisher.GetCollisionEvents(other, collisionEvents);


        int i = 0;

        while (i < numFireCollisionEvents)
        {
           
                transform.localScale *= 1.1f;
            
            i++;
        }

        i = 0;
        
        while (i < numExtinguisherCollisionEvents)
        {

            transform.localScale *= 0.9f;

            i++;
        }
    }
}
