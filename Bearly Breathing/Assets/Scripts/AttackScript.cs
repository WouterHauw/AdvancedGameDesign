using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AttackScript : MonoBehaviour, AbilityInterface
{
    public GameObject BearClaw;
    private RaycastHit _hit;
    [SerializeField] private float _bearActiveTime;
    [SerializeField] private readonly float _range = 10f;

    [SerializeField] private GameObject explosion;
    [SerializeField] private float time;

    private GameObject instantiatedObj;
    [SerializeField] private float theTimeBetweenFlashes;
    private bool isFlashing;

    [SerializeField] private float range;

    [SerializeField] private int testOption;
    private bool isBeingDestroyed;


    // Use this for initialization
    void Start()
    {
        InitializeVariables();
    }
   
    //Must be public as its used in interface
    public void InitializeVariables()
    {
        _bearActiveTime = 3f;
        testOption = 1;
        theTimeBetweenFlashes = 0.2f;
        range = 5;
        isBeingDestroyed = false;
    }
   
    //Must be public as its used in interface
    //Launch an explosion and bearclaw on GUI
    public void ActivateAbility()
    {
        var vectorForwards = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, vectorForwards, out _hit, _range))
        {
            if (_hit.transform.gameObject.tag == "Sheep")
            {
                InitializeExplosion();

                
                StartCoroutine(BearClawCourotine());
            }
        }
    }

    public void DeactivateAbility()
    {

    }

    private IEnumerator BearClawCourotine()
    {
        BearClaw.SetActive(true);
        yield return new WaitForSeconds(_bearActiveTime);
        BearClaw.SetActive(false);
    }

    private void InitializeExplosion()
    {
        _hit.transform.gameObject.SetActive(false);
        instantiatedObj = (GameObject)Instantiate(explosion, _hit.transform.position,
            Quaternion.LookRotation(Vector3.up));
        Destroy(instantiatedObj, time);
    }


    /**private IEnumerator StartFlashing(GameObject sheep)
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
    }**/
}
