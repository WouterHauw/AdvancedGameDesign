using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LavaScript : MonoBehaviour {
    public Transform[] Waypoints;
    public GameObject platform;
    public float speed = 2;
 

    public int CurrentPoint = 0;

    // Use this for initialization
    void Start() {
        if (platform == null) { 
            platform = GameObject.FindWithTag("PlatformTag");
        }

        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
   

    // Update is called once per frame
    void Update () {
        if (transform.position.y != Waypoints[CurrentPoint].transform.position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentPoint].transform.position, speed * Time.deltaTime);
        }

        if (transform.position.y == Waypoints[CurrentPoint].transform.position.y)
        {
            CurrentPoint += 1;
        }
        if (CurrentPoint >= Waypoints.Length)
        {
            CurrentPoint = 0;
        }
   
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
     
         if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("DeathScene");       
    
        }

    }

}
