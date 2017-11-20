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
        HandleAttackInput();
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
