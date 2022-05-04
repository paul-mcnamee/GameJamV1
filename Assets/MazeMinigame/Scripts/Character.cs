using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
[RequireComponent(typeof(PlayerInput))]
public class Character : MonoBehaviour
{

    public float delta = 0.1f;
    public GameObject goal;
    Character character;
    Animator animator;
    Rigidbody2D rigidbody;
    public GameObject flashlight;
    public GameObject mask;
    public InputAction moveAction;

    private Vector2 moveForce = Vector2.zero;
     

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
        
        //if (!Input.anyKey)
        //    animator.enabled = false;
        //else
        //    animator.enabled = true;

        rigidbody.AddForce(moveForce.normalized*delta, ForceMode2D.Impulse);
        
        character.transform.rotation = Quaternion.FromToRotation(Vector2.right, moveForce);
        
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

    private void OnMove(InputValue value)
    {
        moveForce = value.Get<Vector2>();
    }

   
}
