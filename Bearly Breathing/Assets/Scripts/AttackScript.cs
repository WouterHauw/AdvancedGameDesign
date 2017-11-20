using System.Collections;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject bearClaw;

    [SerializeField] private float _bearActiveTime = 3f;
    [SerializeField] private readonly float _range = 10;

    [SerializeField] private int _testOption = 1;
    [SerializeField] private float _theTimeBetweenFlashes;
    [SerializeField] private float _time;

    [SerializeField] private GameObject explosion;
    [SerializeField] private float range;


    private RaycastHit _hit;
    private GameObject _instantiatedObj;
    private bool _isBeingDestroyed;
    private bool _isFlashing;


    // Use this for initialization
    private void Start()
    {
        _theTimeBetweenFlashes = 0.2f;
        range = 5;
        _isBeingDestroyed = false;
    }

    public void Attack()
    {
        var vectorForwards = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, vectorForwards, out _hit, _range))
        {
            if (_hit.transform.gameObject.tag == "Sheep")
            {
                if (_testOption == 1)
                {
                    _hit.transform.gameObject.SetActive(false);
                    _instantiatedObj = Instantiate(explosion, _hit.transform.position,
                        Quaternion.LookRotation(Vector3.up));
                    Destroy(_instantiatedObj, _time);
                }
                else if (_testOption == 2)
                {
                    StartCoroutine(StartFlashing(_hit.transform.gameObject));
                }
                StartCoroutine(BearClawCourotine());
            }
        }
    }

    private IEnumerator BearClawCourotine()
    {
        bearClaw.SetActive(true);
        yield return new WaitForSeconds(_bearActiveTime);
        bearClaw.SetActive(false);
    }


    private IEnumerator StartFlashing(GameObject sheep)
    {
        if (_isBeingDestroyed)
        {
            yield break;
        }

        sheep.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        sheep.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        sheep.SetActive(false);
        yield return new WaitForSeconds(_theTimeBetweenFlashes);
        sheep.SetActive(true);
        yield return new WaitForSeconds(_theTimeBetweenFlashes);
        DestroyObject(sheep.gameObject);
        _isBeingDestroyed = true;
    }
}