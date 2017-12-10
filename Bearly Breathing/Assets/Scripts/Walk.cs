using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : SheepFSM
{
    private GameObject[] _waypoints;
    private int _currentWP;

    private void Awake()
    {
        _waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_waypoints.Length == 0) return;
        if (Vector3.Distance(_waypoints[_currentWP].transform.position,
            NPCSheep.transform.position) < _accuracy)
        {
            _currentWP = Random.Range(0, _waypoints.Length);

            if (_currentWP >= _waypoints.Length)
            {
                _currentWP = 0;
            }
        }
        sheep.SetDestination(_waypoints[_currentWP].transform.position);
    }
}
