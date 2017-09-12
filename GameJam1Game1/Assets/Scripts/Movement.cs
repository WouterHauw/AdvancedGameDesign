using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    public float jumpSpeed;
    public bool isGrounded = false;
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float jumpHeight;

    // Use this for initialization
    void Start () {
        //GetComponent<Rigidbody2D>().isKinematic = true;
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
        float horizontal = Input.GetAxis("Horizontal");


        HandleMovement(horizontal);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            myRigidBody.velocity = new Vector2(0, jumpHeight*jumpSpeed);
        }
    }

    private void HandleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "StarTag")
        {
            SceneManager.LoadScene("VictoryScene");

        }else if (collision.gameObject.tag == "PlatformTag")
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }


}
