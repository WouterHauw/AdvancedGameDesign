using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D myRigidBody;

    [SerializeField]
    private float movementSpeed;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        HandleHorizontal(horizontal);
        HandleVertical(vertical);

        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    myRigidBody.velocity = new Vector2(movementSpeed * Time.deltaTime, myRigidBody.velocity.y);
        //}

        
    }

    private void HandleHorizontal(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
    }

    private void HandleVertical(float vertical)
    {
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, vertical * movementSpeed);
    }
}
