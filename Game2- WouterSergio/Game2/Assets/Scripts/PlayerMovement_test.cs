using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_test : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool isGrounded;
    public LayerMask whatIsground;

    public Collider2D myCollider;

    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }


    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsground);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        }

    }
}
