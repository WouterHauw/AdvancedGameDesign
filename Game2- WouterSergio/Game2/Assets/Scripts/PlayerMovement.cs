using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ground;
    public float jumpPower = 2f;
    public float walkSpeed = 2f;

    private Rigidbody2D rigid;
    private BoxCollider2D collider;
    private RaycastHit hit;
    private float distToTheGround;
    private Dictionary<KeyCode, Vector3> directions;

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
        rigid.AddForce(transform.up * 9 ,ForceMode2D.Impulse);
    }
}
