using UnityEngine;

public class Scout : HunterFSM
{
    private int _currentWp;

    private GameObject[] _waypoints;

    private void Awake()
    {
        _waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        opponent.GetComponent<PlayerController>().beingChased = false;
        _currentWp = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hunter.speed = 15;
        if (_waypoints.Length == 0)
        {
            return;
        }
        if (Vector3.Distance(_waypoints[_currentWp].transform.position,
                npcHunter.transform.position) < accuracy)
        {
            _currentWp = Random.Range(0, _waypoints.Length);
            if (_currentWp >= _waypoints.Length)
            {
                _currentWp = 0;
            }
        }

        hunter.SetDestination(_waypoints[_currentWp].transform.position);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hunter.speed = 3.5f;
    }
}