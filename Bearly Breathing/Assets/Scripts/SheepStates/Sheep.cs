using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sheep : MonoBehaviour
{
    public Animator anim { get; set; }
    public NavMeshAgent sheepAgent;
    public int currentWP;
    public float accuracy = 3;
    public float distance;

    private ISheepState currentState;
    private Transform _playerTransform;
    private Transform _sheepTransform;
    private GameObject[] _waypoints;
    private NavMeshHit _navHit;

    // Use this for initialization
    void Start()
    {
        // Idle is default state
        ChangeState(new IdleState());

        anim = GetComponent<Animator>();
        _waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _sheepTransform = GameObject.FindGameObjectWithTag("SheepTransform").transform;
        sheepAgent = GameObject.FindGameObjectWithTag("SheepTransform").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute();
        distance = Vector3.Distance(_sheepTransform.position, _playerTransform.position);
    }

    public void ChangeState(ISheepState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    public void Move()
    {
        if (_waypoints.Length == 0) return;
        if (Vector3.Distance(_waypoints[currentWP].transform.position,
            _sheepTransform.position) < accuracy)
        {
            currentWP = Random.Range(0, _waypoints.Length);

            if (currentWP >= _waypoints.Length)
            {
                currentWP = 0;
            }
        }

        sheepAgent.SetDestination(_waypoints[currentWP].transform.position);
    }

    public void Run()
    {
        Vector3 runTo = _sheepTransform.position + (_sheepTransform.position - _playerTransform.position);
        if (NavMesh.SamplePosition(runTo, out _navHit, 3.0f, NavMesh.AllAreas))
        {
            sheepAgent.destination = _navHit.position;
            sheepAgent.speed = 5;
        }
    }
}
