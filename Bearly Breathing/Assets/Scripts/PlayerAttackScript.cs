using System.Collections;
using UnityEngine;


public class PlayerAttackScript : MonoBehaviour, IAbilityInterface
{
    private RaycastHit _hit;
    [SerializeField] private float _bearActiveTime;
    [SerializeField] private GameObject _bearClaw;
    [SerializeField] private float _range;
    [SerializeField] private GameObject _specialEffect;
    [SerializeField] private GameObject _textSpecialEffect;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _playerAttack;

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
        _audioSource = GetComponent<AudioSource>();
        _bearActiveTime = 0.5f;
        _range = 2f;
        PlayerController script = GetComponent<PlayerController>();
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
            _audioSource.PlayOneShot(_playerAttack, 0.5f);
            GameManager.Instance.currentScore++;
        }
        if (hitColliders[0].gameObject.CompareTag("Hunter"))
        {
            hitColliders[0].gameObject.SetActive(false);
            StartCoroutine(BearClawCourotine());
            _audioSource.PlayOneShot(_playerAttack, 0.5f);
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
        GameObject instantiatedObj = Instantiate(_specialEffect);
        instantiatedObj.transform.position = collider.gameObject.transform.position;
        instantiatedObj.transform.Translate(Vector3.back * 2);

        instantiatedObj = Instantiate(_textSpecialEffect);
        instantiatedObj.transform.position = collider.gameObject.transform.position;
        instantiatedObj.transform.Translate(Vector3.back * 2);
    }

    //defines the attack sightRange of the player
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}

