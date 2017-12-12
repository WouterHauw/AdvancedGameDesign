using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum Demo
{
    Demo1,
    Demo2,
    Demo3
}



public class PlayerController : MonoBehaviour
{
    public GameObject bearClaw;
    public GameObject[] collisionEffects;
    public GameObject[] cartoonBubbles;
    public GameObject[] textBubbles;
    public Demo thisDemo;
    [SerializeField] private MovementScript _playerMoverment = null;
    [SerializeField] private AttackScript _playerAttack = null;
    public float health;
    public float maxHealth;
    public bool beingChased;
    public bool isHiding;
    public int _currentScore;
    [SerializeField] private InputScript _inputScript = null;
    public Component abilityInterface;
    [SerializeField] private AbilityInterface IAbility;
    private Animator anim;


    


    // Use this for initialization
    void Start()
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

    void Update()
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
        if (other.gameObject.tag == "Bush")
        {
            IAbility = gameObject.AddComponent<Bush>();
            IAbility.InitializeVariables();
            IAbility.ActivateAbility(other.gameObject, anim);
        }
    }


    //Deactivate BushAbility
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bush")
        {
            IAbility.DeactivateAbility(other.gameObject, anim);
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
            IAbility.ActivateAbility(null, anim);
           
            _inputScript.isAttacking = false;
        }else
        {
           // IAbility.DeactivateAbility();
            //Destroy(GetComponent<AttackScript>());

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
        switch (thisDemo)
        {
            case Demo.Demo1:
                var random = Random.Range(0, collisionEffects.Length);
                return collisionEffects[random];
            case Demo.Demo2:
                return collisionEffects[1];
            case Demo.Demo3:
                return collisionEffects[1];
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
