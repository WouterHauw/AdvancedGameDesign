using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Ground")
        Destroy(gameObject);
    }

        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
