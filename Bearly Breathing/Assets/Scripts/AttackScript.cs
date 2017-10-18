using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private float time;

    private GameObject instantiatedObj;
    private RaycastHit hit;
    [SerializeField] private float theTimeBetweenFlashes;
    private bool isFlashing;
    
    [SerializeField] private float range;
   
    [SerializeField]private int testOption = 1;
    private bool isBeingDestroyed;
 

    // Use this for initialization
    void Start () {
        theTimeBetweenFlashes = 0.2f;
        range = 10;
        isBeingDestroyed = false;
    }

    public void KillSheeps()
    {
        
        Vector3 VectorForwards = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, VectorForwards, out hit, range))
        {
            if (hit.transform.gameObject.tag == "Sheep")
            {
                if (testOption == 1)
                {
                    hit.transform.gameObject.SetActive(false);
                    instantiatedObj = (GameObject)Instantiate(explosion, hit.transform.position, Quaternion.LookRotation(Vector3.up));
                    Destroy(instantiatedObj, time);
                   
                }
                else if (testOption == 2)
                {
                    StartCoroutine(startFlashing(hit.transform.gameObject));
                }
            }                   
        }
    }

    private IEnumerator startFlashing(GameObject sheep)
    {
        if (isBeingDestroyed) yield break;

        sheep.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        sheep.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        sheep.SetActive(false);
        yield return new WaitForSeconds(theTimeBetweenFlashes);
        sheep.SetActive(true);
        yield return new WaitForSeconds(theTimeBetweenFlashes);
        DestroyObject(sheep.gameObject);
        isBeingDestroyed = true;
    }
}   

