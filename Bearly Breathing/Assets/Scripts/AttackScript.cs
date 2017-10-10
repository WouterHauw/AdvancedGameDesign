﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public float range = 10;
    private RaycastHit hit;

    public GameObject blood;

     

	// Use this for initialization
	void Start () {
		
	}

    public void KillSheeps()
    {
        
        Vector3 VectorForwards = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, VectorForwards, out hit, range))
        {
            if (hit.transform.gameObject.tag == "Sheep")
            {
                hit.transform.gameObject.SetActive(false);
                Instantiate(blood, hit.transform.position, Quaternion.LookRotation(Vector3.up));
            }
        }

    }
}
