using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject BearClaw;
    private RaycastHit _hit;
    [SerializeField] private float _bearActiveTime = 3f;
    [SerializeField] private readonly float _range = 10;

    [SerializeField] private GameObject explosion;
    [SerializeField] private float time;

    private GameObject instantiatedObj;
    [SerializeField] private float theTimeBetweenFlashes;
    private bool isFlashing;

    [SerializeField] private float range;

    [SerializeField] private int testOption = 1;
    private bool isBeingDestroyed;


    // Use this for initialization
    void Start()
    {
        theTimeBetweenFlashes = 0.2f;
        range = 5;
        isBeingDestroyed = false;
    }

    public void Attack()
    {
        var vectorForwards = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, vectorForwards, out _hit, _range))
        {
            if (_hit.transform.gameObject.tag == "Sheep")
            {
                if (testOption == 1)
                {
                    _hit.transform.gameObject.SetActive(false);
                    instantiatedObj = (GameObject) Instantiate(explosion, _hit.transform.position,
                        Quaternion.LookRotation(Vector3.up));
                    Destroy(instantiatedObj, time);

                }
                else if (testOption == 2)
                {
                    StartCoroutine(StartFlashing(_hit.transform.gameObject));
                }
                StartCoroutine(BearClawCourotine());
            }
        }
    }

    private IEnumerator BearClawCourotine()
    {
        BearClaw.SetActive(true);
        yield return new WaitForSeconds(_bearActiveTime);
        BearClaw.SetActive(false);
    }


    private IEnumerator StartFlashing(GameObject sheep)
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
