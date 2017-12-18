using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sheep : MonoBehaviour
{
    public Animator anim { get; set; }
    public NavMeshAgent sheepAgent;
    public Transform playerTransform;
    public Transform sheepTransform;
    public float distance;
    private ISheepState _currentState;

    // Use this for initialization
    void Start()
    {
        // Idle is default state
        ChangeState(new IdleState());

        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        sheepTransform = GameObject.FindGameObjectWithTag("SheepTransform").transform;
        sheepAgent = GameObject.FindGameObjectWithTag("SheepTransform").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(sheepTransform.position, playerTransform.position);
        _currentState.Execute();
    }

    public void ChangeState(ISheepState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;

        _currentState.Enter(this);
    }
}
