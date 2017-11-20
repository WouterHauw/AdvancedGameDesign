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
    [SerializeField] private InputScript _inputScript = null;

    
    // Use this for initialization
    void Start()
    {
        _playerMoverment = GetComponent<MovementScript>();
        _playerAttack = GetComponent<AttackScript>();
        _inputScript = FindObjectOfType<InputScript>();
        //_playerMoverment.SecondDemoIsPlaying = _inputScript.enableSecondProtype;
        maxHealth = 100f;
        health = maxHealth;
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
        if (!(movement.x > 0) && !(movement.y > 0))
        {
            return false;
        }
        _playerMoverment.moveDirection = new Vector3(movement.x, 0, movement.y);
        return true;
    }

    private void HandleAttackInput()
    {
        //handles the attacks of the player
        var isAttacking = _inputScript.isAttacking;

        if (isAttacking)
        {
            _playerAttack.Attack();
            _inputScript.isAttacking = false;
        }

    }

   
}
