using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject BearClaw;
    [SerializeField] private MovementScript _playerMoverment = null;
    [SerializeField] private AttackScript _playerAttack = null;

    [SerializeField] private InputScript _inputScript = null;

    
    // Use this for initialization
    void Start()
    {
        _playerMoverment = GetComponent<MovementScript>();
        _playerAttack = GetComponent<AttackScript>();
        _inputScript = FindObjectOfType<InputScript>();
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

    private void HandleMoveInput()
    {

        //handles movement of the player
        var movement = _inputScript.GetDirection();
        if (_inputScript.EnableSecondProtype)
        {
            return;
        }
        _playerMoverment.MoveDirection = new Vector3(movement.x, 0, movement.y);
        _playerMoverment.LookDirection = new Vector3(movement.x, 0, movement.y);
    }

    private void HandleAttackInput()
    {
        //handles the attacks of the player
        var isAttacking = _inputScript.IsAttacking;

        if (isAttacking)
        {
            _playerAttack.Attack();
            _inputScript.IsAttacking = false;
        }

    }

   
}
