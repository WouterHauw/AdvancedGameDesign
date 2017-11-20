using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject BearClaw;
    [SerializeField] private MovementScript _playerMoverment = null;
    [SerializeField] private AttackScript _playerAttack = null;
    public float health;
    public float maxHealth;
    public bool beingChased;
    public bool isHiding;
    [SerializeField] private InputScript _inputScript = null;
    public Component abilityInterface;
    [SerializeField] private AbilityInterface IAbility;

    
    // Use this for initialization
    void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        //To prevent Unity from creating multiple copies of the same component in inspector at runtime
        abilityInterface = gameObject.GetComponent<AbilityInterface>() as Component;

        _playerMoverment = GetComponent<MovementScript>();
        _playerAttack = GetComponent<AttackScript>();
        _inputScript = FindObjectOfType<InputScript>();
        maxHealth = 100f;
        health = maxHealth;
        isHiding = false;
    }

    void Update()
    {
        if (_playerMoverment == null || _inputScript == null || _playerAttack == null)
        {
            Debug.Log("One of Script is missing");
            return;
        }
        HandleAttackInput();
    }

    //Activate BushAbility
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bush")
        {
            Debug.Log("entered Bush");
            IAbility = gameObject.AddComponent<Bush>();
            IAbility.InitializeVariables();
            IAbility.ActivateAbility(other.gameObject);
        }
    }

    //Deactivate BushAbility
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bush")
        {
            IAbility.DeactivateAbility(other.gameObject);
            Destroy(GetComponent<Bush>());  
        }
    }

    private void HandleAttackInput()
    {
        //handles the attacks of the player
        bool isAttacking = _inputScript.isAttacking;
        
        if (isAttacking)
        {
            
            IAbility = gameObject.AddComponent<AttackScript>();
            IAbility.InitializeVariables();
            IAbility.ActivateAbility(null);
            _inputScript.isAttacking = false;
        }else
        {
           // IAbility.DeactivateAbility();
            //Destroy(GetComponent<AttackScript>());
        }

    } 
}
