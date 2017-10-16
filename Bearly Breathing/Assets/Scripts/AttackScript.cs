using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public float range = 10;
    public float time;
    public Vector3 targetScale = new Vector3(5,5,5);
    public float growthSpeed = 0.5f;


    public GameObject explosion;

    private GameObject instantiatedObj;
    private RaycastHit hit;

    private bool growth = false;
    protected Vector3 targetedGrowth;




    // Use this for initialization
    void Start () {
		
	}

    private void Update()
    {
       
    }


    public void KillSheeps()
    {
        
        Vector3 VectorForwards = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, VectorForwards, out hit, range))
        {
            if (hit.transform.gameObject.tag == "Sheep")
            {
                   
                hit.transform.gameObject.SetActive(false);
                instantiatedObj = instantiatedObj = (GameObject)Instantiate(explosion, hit.transform.position, Quaternion.LookRotation(Vector3.up));
                Destroy(instantiatedObj, time);
                growth = false;
                
            }
        }

    }   
}
