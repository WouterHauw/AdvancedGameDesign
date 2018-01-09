using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public IAbilityInterface abilityInterface;
    public GameObject bearClaw;
    public bool beingChased;
    public GameObject[] cartoonBubbles;
    public GameObject[] collisionEffects;
    public int currentScore;
    public float health;
    public bool isHiding;
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
        GetComponent<AttackScript>();
        _inputScript = FindObjectOfType<InputScript>();
        maxHealth = 100f;
        health = maxHealth;
        isHiding = false;
    }

    private void Update()
    {
        if (_inputScript == null)
        {
            Debug.Log("One of Script is missing");
            return;
        }

        HandleAttackInput();
    }

    //Activate BushAbility
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            _ability = gameObject.AddComponent<Bush>();
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
            _ability = gameObject.AddComponent<AttackScript>();
            _ability.InitializeVariables();
            _ability.ActivateAbility(null, _anim);

            _inputScript.isAttacking = false;
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    //method for use for the attack button
    public void Attack()
    {
        _ability = gameObject.AddComponent<AttackScript>();
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