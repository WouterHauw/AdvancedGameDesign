using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ground;
    public float jumpPower = 6f;
    public float walkSpeed = 2f;

    private Rigidbody2D rigid;
    private BoxCollider2D collider;
    private RaycastHit hit;
    private float distToTheGround;
    private Dictionary<KeyCode, Vector3> directions;
    private bool IsOnJumpPlatform = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }


    void Start()
    {
        directions = new Dictionary<KeyCode, Vector3>()
        {
            
            {KeyCode.A, Vector3.left}, 
            {KeyCode.D, Vector3.right},
            {KeyCode.W,Vector3.up }
            
        }; 
    distToTheGround = collider.bounds.extents.y;
    }
	// Use this for initialization
   


	
	// Update is called once per frame
	void FixedUpdate () {

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (Physics.Raycast(transform.position, -Vector3.up, distToTheGround+0.1f))
        //    {
        //       Jump();
	    //    }
	    //}
	    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
	    {
            Jump();
        }
        foreach (var direction in directions.Keys)
	    {
	        if (Input.GetKey(direction))
	        {
	            
	               this.transform.Translate(directions[direction] * walkSpeed * Time.deltaTime, Space.Self);
                
	            
            }
	    }
	}

    void Jump()
    {
        if (IsOnJumpPlatform)
        {
            jumpPower = 9;
        }
        else
        {
            jumpPower = 5;
        }
        rigid.AddForce(transform.up * jumpPower ,ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boost")
        {
            foreach (var direction in directions.Keys)
            {
                if (Input.GetKey(direction))
                {

                    rigid.AddForce(directions[direction] * 8, ForceMode2D.Impulse);


                }
            }
            
        }
        if (collision.gameObject.tag == "JumpPlatform")
        {
            IsOnJumpPlatform = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "JumpPlatform")
        {
            IsOnJumpPlatform = false;
        }
    }
}
