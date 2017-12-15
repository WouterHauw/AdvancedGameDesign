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

    public static int radius = 5;
    public static Vector3 goalPos = Vector3.zero;

    private ISheepState _currentState;
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
        _currentState.Execute();
        distance = Vector3.Distance(_sheepTransform.position, _playerTransform.position);
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

    public void Move()
    {
        if (Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
            sheepAgent.destination = goalPos;
        }
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
