using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class Character : MonoBehaviour
{

    public float delta = 0.1f;
    public GameObject goal;
    Character character;
    Animator animator;
    Rigidbody2D rigidbody;
    public GameObject flashlight;
    public GameObject mask;

    

    private void Awake()
    {
        character = GetComponent<Character>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        Vector2 newPos = Vector2.zero;
        newPos.x = Input.GetAxisRaw("Horizontal");
        newPos.y = Input.GetAxisRaw("Vertical");
        if (!Input.anyKey)
            animator.enabled = false;
        else
            animator.enabled = true;

        rigidbody.AddForce(newPos.normalized*delta, ForceMode2D.Impulse);
        
        character.transform.rotation = Quaternion.FromToRotation(Vector2.right, newPos);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == goal)
        {
            character.gameObject.SetActive(false);
            
            Debug.Log("Game won");

        }
        if (collision.gameObject.GetComponent<Powerup>() != null)
        {
            Debug.Log("powerup triggered");
            collision.gameObject.GetComponent<Powerup>().powerup(gameObject);
        }

    }


   
}
