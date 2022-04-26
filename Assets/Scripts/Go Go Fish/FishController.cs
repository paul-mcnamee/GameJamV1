using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float speed;
    public float power;
    public byte lives;
    public float maxVelocity;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move fish at constant rate if alive
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //if mouse clicking, go up
        if (Input.GetMouseButton(0))
        {
            rigidbody.AddForce((Vector2.up * power) * Time.deltaTime, ForceMode2D.Impulse);
            //transform.Translate( ( Vector2.up * power) * Time.deltaTime);
        }
    }

    
    void FixedUpdate()
    {
       rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxVelocity);
    }
}
