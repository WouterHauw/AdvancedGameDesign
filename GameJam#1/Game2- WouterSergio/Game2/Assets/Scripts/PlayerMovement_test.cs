using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_test : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;

    public float boostSpeed = 10.0f;
    public float boostDuration = 2.0f;

    private Rigidbody2D myRigidbody;

    public bool isGrounded;
    public bool isCollision;
    public LayerMask whatIsground;

    float timerLength = 10.0f;//The length of time in seconds.
    float timerTimePassed = 0.0f;//The variable that will store the time passed while the timer is going.
    bool runTimer = false;//Used to start/stop the timer.

    public Collider2D myCollider;

    public GameObject enemy;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boost")
        {
            isCollision = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boost")
        {

            isCollision = true;
            runTimer = true;

            moveSpeed += 5;


            if (runTimer)
            {
                timerTimePassed += Time.deltaTime;
                if (timerTimePassed >= timerLength)
                {
                    timerTimePassed = 0f;
                    runTimer = false;
                    moveSpeed = 5;

                }
            }

        }

        if (collision.gameObject.tag == "Enemy")
        {
            moveSpeed = 0;
        }
    }
}




