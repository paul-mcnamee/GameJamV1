using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D coll;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        //coll.friction
        
    }

    // Disables gravity on all rigidbodies entering this collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collider enter");
        if (other.attachedRigidbody)
        {
            Debug.Log("collider detected");
            other.attachedRigidbody.gravityScale = 0.2F;
        }
            
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("collider exit");
        if (other.attachedRigidbody)
        {
            Debug.Log("collider detected");
            other.attachedRigidbody.gravityScale = 1F;
        }
    }
}
