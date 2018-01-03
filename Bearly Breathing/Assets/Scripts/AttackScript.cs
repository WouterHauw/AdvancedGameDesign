﻿using System.Collections;
using System.Linq;
using UnityEngine;

public class AttackScript : MonoBehaviour, AbilityInterface
{
    [SerializeField]private GameObject _bearClaw;
    private RaycastHit _hit;
    [SerializeField] private float _bearActiveTime;
    [SerializeField] private float _range ;
    [SerializeField] private float _theTimeBetweenFlashes;
    [SerializeField] private float _time;
    [SerializeField] private GameObject specialEffect;
    [SerializeField] private GameObject textSpecialEffect;
    [SerializeField] private AbilityInterface IAbility;
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
        _range = 2f;
        _isBeingDestroyed = false;
        var script = GetComponent<PlayerController>();
        _bearClaw = script.bearClaw;
        specialEffect = script.GetParticleEffect();
        textSpecialEffect = script.GetTextParticleEffect();
    }
   
    //Must be public as its used in interface
    //Launch an explosion and bearclaw on GUI
    public void ActivateAbility(GameObject aObject, Animator playerAnimation)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _range,LayerMask.GetMask("Player"));
        if (hitColliders.Length == 0)
        {
            return;
        }
        if (hitColliders[0].gameObject.CompareTag("Sheep"))
        {
            SetExplosions(hitColliders[0]);
            hitColliders[0].gameObject.SetActive(false);
            StartCoroutine(BearClawCourotine());
            playerAnimation.SetTrigger("isAttacking");

        }
        if (hitColliders[0].gameObject.CompareTag("Hunter"))
        {
            hitColliders[0].gameObject.SetActive(false);
            StartCoroutine(BearClawCourotine());
            playerAnimation.SetTrigger("isAttacking");

        }
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

    private void SetExplosions(Component collider)
    {
        var instantiatedObj = Instantiate(specialEffect);
        instantiatedObj.transform.position = collider.gameObject.transform.position;
        instantiatedObj.transform.Translate(Vector3.back * 2);

        instantiatedObj = Instantiate(textSpecialEffect);
        instantiatedObj.transform.position = collider.gameObject.transform.position;
        instantiatedObj.transform.Translate(Vector3.back * 2);

    }

    //private void InitializeExplosion()
    //{
    //    _hit.transform.gameObject.SetActive(false);
    //    _instantiatedObj = Instantiate(explosion, _hit.transform.position,
    //        Quaternion.LookRotation(Vector3.up));
    //    Destroy(_instantiatedObj, _time);
    //}
    //defines the attack range of the player
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position , _range);
    }
}

       

