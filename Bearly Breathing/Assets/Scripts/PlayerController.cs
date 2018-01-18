using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public IAbilityInterface abilityInterface;
    public GameObject bearClaw;
    public int previousHealth;
    public bool beingChased;
    public GameObject[] cartoonBubbles;
    public GameObject[] collisionEffects;
    private int health;
    public bool isHiding;

    private UIManagerScript _UIScript;
    public float maxHealth;
    public GameObject[] textBubbles;
    [SerializeField] private IAbilityInterface _ability;
    private Animator _anim;
    [SerializeField] private InputScript _inputScript;

    



    // Use this for initialization
    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        //To prevent Unity from creating multiple copies of the same component in inspector at runtime
        _anim = GetComponent<Animator>();
        _inputScript = FindObjectOfType<InputScript>();
        _UIScript = FindObjectOfType<UIManagerScript>();
        GameManager.Instance.health = 3;        

        isHiding = false;
    }

    private void Update()
    {
        if (_inputScript == null)
        {
            return;
        }

        HandleAttackInput();

        ChangeInHealth();
    }

    //Activate BushAbility
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            if (!gameObject.GetComponent<Bush>()) {
               
                _ability = gameObject.AddComponent<Bush>();
            }
            else
            {
                _ability = gameObject.GetComponent<Bush>();
            }
            _ability.InitializeVariables();
            _ability.ActivateAbility(other.gameObject, _anim);
        }
         }


    //Deactivate BushAbility
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            _ability.DeactivateAbility(other.gameObject, _anim);
            Destroy(GetComponent<Bush>());
        }
    }

    private void HandleAttackInput()
    {
        //handles the attacks of the player
        var isAttacking = _inputScript.isAttacking;

        if (isAttacking)
        {
            _ability = gameObject.AddComponent<PlayerAttackScript>();
            _ability.InitializeVariables();
            _ability.ActivateAbility(null, _anim);

            _inputScript.isAttacking = false;
        }
    }

    private void ChangeInHealth()
    {
        
        if (previousHealth > GameManager.Instance.health || previousHealth < GameManager.Instance.health) // greater than
        {
            previousHealth = GameManager.Instance.health;
            _UIScript.SetHealthSlider();
        }
    }

    //method for use for the attack button
    public void Attack()
    {
        if (!gameObject.GetComponent<PlayerAttackScript>())
        {
            _ability = gameObject.AddComponent<PlayerAttackScript>();
        }
        else
        {
            _ability = gameObject.GetComponent<PlayerAttackScript>();
        }
        _ability.InitializeVariables();
        _ability.ActivateAbility(null, _anim);
        
    }

    public GameObject GetParticleEffect()
    {
        var randcollisioneffects = Random.Range(0, collisionEffects.Length);
        return collisionEffects[randcollisioneffects];
    }

    public GameObject GetTextParticleEffect()
    {
        var randtextbubble = Random.Range(0, textBubbles.Length);
        return textBubbles[randtextbubble];
    }
}