using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int _currentScore;
    public Component abilityInterface;
    public GameObject bearClaw;
    public bool beingChased;
    public GameObject[] cartoonBubbles;
    public GameObject[] collisionEffects;
    public float health;
    public bool isHiding;
    public float maxHealth;
    public GameObject[] textBubbles;
    [SerializeField] private InputScript _inputScript;
    [SerializeField] private AttackScript _playerAttack;
    [SerializeField] private MovementScript _playerMoverment;
    private Animator anim;
    [SerializeField] private AbilityInterface IAbility;


    // Use this for initialization
    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        //To prevent Unity from creating multiple copies of the same component in inspector at runtime
        abilityInterface = gameObject.GetComponent<AbilityInterface>() as Component;
        anim = GetComponent<Animator>();
        _playerMoverment = GetComponent<MovementScript>();
        _playerAttack = GetComponent<AttackScript>();
        _inputScript = FindObjectOfType<InputScript>();
        maxHealth = 100f;
        health = maxHealth;
        isHiding = false;
    }

    private void Update()
    {
        if (_playerMoverment == null || _inputScript == null)
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
            IAbility = gameObject.AddComponent<Bush>();
            IAbility.InitializeVariables();
            IAbility.ActivateAbility(other.gameObject, anim);
        }
    }


    //Deactivate BushAbility
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            IAbility.DeactivateAbility(other.gameObject, anim);
            Destroy(GetComponent<Bush>());
        }
    }

    private void HandleAttackInput()
    {
        //handles the attacks of the player
        var isAttacking = _inputScript.isAttacking;

        if (isAttacking)
        {
            IAbility = gameObject.AddComponent<AttackScript>();
            IAbility.InitializeVariables();
            IAbility.ActivateAbility(null, anim);

            _inputScript.isAttacking = false;
        }
    }

    public void die()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    //method for use for the attack button
    public void Attack()
    {
        IAbility = gameObject.AddComponent<AttackScript>();
        IAbility.InitializeVariables();
        IAbility.ActivateAbility(null, anim);
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