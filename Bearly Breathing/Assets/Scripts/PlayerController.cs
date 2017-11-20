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
        _playerMoverment.SecondDemoIsPlaying = _inputScript.EnableSecondProtype;
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
        HandleMoveInput();
        HandleAttackInput();
    }

    public bool HandleMoveInput()
    {

        //handles movement of the player
        var movement = _inputScript.GetDirection();
        if (_inputScript.EnableSecondProtype)
        {
            return false;
        }
        _playerMoverment.MoveDirection = new Vector3(movement.x, 0, movement.y);
        _playerMoverment.LookDirection = new Vector3(movement.x, 0, movement.y);

        return true;
    }

    //Activate BushAbility
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bush")
        {
            IAbility = gameObject.AddComponent<Bush>();
            IAbility.InitializeVariables();
            IAbility.ActivateAbility();
        }
    }

    //Deactivate BushAbility
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bush")
        {
            IAbility = gameObject.AddComponent<Bush>();
            IAbility.DeactivateAbility();
        }
    }

    private void HandleAttackInput()
    {
        //handles the attacks of the player
        bool isAttacking = _inputScript.IsAttacking;
        IAbility = gameObject.AddComponent<AttackScript>();

        if (isAttacking)
        {
          
            IAbility.InitializeVariables();
            IAbility.ActivateAbility();
            _inputScript.IsAttacking = false;
        }else
        {
            IAbility.DeactivateAbility();
        }

    }

   
}
