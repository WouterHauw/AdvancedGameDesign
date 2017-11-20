using System.Collections;
using UnityEngine;

public class AttackScript : MonoBehaviour, AbilityInterface
{
    [SerializeField]private GameObject _bearClaw;
    private RaycastHit _hit;
    [SerializeField] private float _bearActiveTime;
    [SerializeField] private float _range ;
    [SerializeField] private float _theTimeBetweenFlashes;
    [SerializeField] private float _time;
    [SerializeField] private GameObject explosion;
    [SerializeField] private AbilityInterface IAbility;


    private GameObject _instantiatedObj;
    private bool _isBeingDestroyed;
    private bool _isFlashing;


    // Use this for initialization
    private void Start()
    {

        InitializeVariables();
    }
   
    //Must be public as its used in interface
    public void InitializeVariables()
    {
        _bearActiveTime = 0.5f;
        _theTimeBetweenFlashes = 0.2f;
        _range = 10f;
        _isBeingDestroyed = false;
        var script = GetComponent<PlayerController>();
        _bearClaw = script.bearClaw;
    }
   
    //Must be public as its used in interface
    //Launch an explosion and bearclaw on GUI
    public void ActivateAbility(GameObject aObject, Animator playerAnimation)
    {
        StartCoroutine(BearClawCourotine());
        playerAnimation.SetTrigger("isAttacking");
        //var vectorForwards = transform.TransformDirection(Vector3.forward);
        //if (Physics.Raycast(transform.position, vectorForwards, out _hit, _range))
        //{
        //    if (_hit.transform.gameObject.tag == "Sheep")
        //    {
        //        InitializeExplosion();

        //        StartCoroutine(BearClawCourotine());
        //    }
        //}
    }

    public void DeactivateAbility(GameObject aObject, Animator playerAnimation)
    {
        //TODO: can be used in case stuff needs deconstructing
    }

    private IEnumerator BearClawCourotine()
    {
        _bearClaw.SetActive(true);
        yield return new WaitForSeconds(_bearActiveTime);
        _bearClaw.SetActive(false);
    }

    private void InitializeExplosion()
    {
        _hit.transform.gameObject.SetActive(false);
        _instantiatedObj = Instantiate(explosion, _hit.transform.position,
            Quaternion.LookRotation(Vector3.up));
        Destroy(_instantiatedObj, _time);
    }
}

       

