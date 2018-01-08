using System.Collections;
using UnityEngine;

public class AttackScript : MonoBehaviour, IAbilityInterface
{
    [SerializeField] private float _bearActiveTime;
    [SerializeField] private GameObject _bearClaw;
    [SerializeField] private float _range;
    [SerializeField] private GameObject _specialEffect;
    [SerializeField] private GameObject _textSpecialEffect;


    //Must be public as its used in interface
    public void InitializeVariables()
    {
        _bearActiveTime = 0.5f;
        _range = 2f;
        var script = GetComponent<PlayerController>();
        _bearClaw = script.bearClaw;
        _specialEffect = script.GetParticleEffect();
        _textSpecialEffect = script.GetTextParticleEffect();
    }

    //Must be public as its used in interface
    //Launch an explosion and bearclaw on GUI
    public void ActivateAbility(GameObject aObject, Animator playerAnimation)
    {
        var hitColliders = Physics.OverlapSphere(transform.position, _range, LayerMask.GetMask("Player"));
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


    // Use this for initialization
    private void Start()
    {
        InitializeVariables();
    }

    private IEnumerator BearClawCourotine()
    {
        _bearClaw.SetActive(true);
        yield return new WaitForSeconds(_bearActiveTime);
        _bearClaw.SetActive(false);
    }

    private void SetExplosions(Component collider)
    {
        var instantiatedObj = Instantiate(_specialEffect);
        instantiatedObj.transform.position = collider.gameObject.transform.position;
        instantiatedObj.transform.Translate(Vector3.back * 2);

        instantiatedObj = Instantiate(_textSpecialEffect);
        instantiatedObj.transform.position = collider.gameObject.transform.position;
        instantiatedObj.transform.Translate(Vector3.back * 2);
    }

    //defines the attack range of the player
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}