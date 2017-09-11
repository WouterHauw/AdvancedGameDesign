using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D myRigidBody;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float jumpHeight;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Horizontal");


        HandleMovement(horizontal);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = new Vector2(0, jumpHeight);
        }
    }

    private void HandleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
       
    }
}
