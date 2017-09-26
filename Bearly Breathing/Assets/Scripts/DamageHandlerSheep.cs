using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandlerSheep : MonoBehaviour {

    public float health = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (health == 0)
        {
            Destroy(gameObject);
        }

    }
}
