using UnityEngine;

public class Patrol : HunterFSM
{
    private int _currentWp;
    private GameObject[] _waypoints;

    private void Awake()
    {
        _waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _currentWp = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
        //var direction = waypoints[currentWP].transform.position - Sheep.transform.position;
        //Sheep.transform.rotation = Quaternion.Slerp(Sheep.transform.rotation,
        //                           Quaternion.LookRotation(direction),
        //                           1.0f * Time.deltaTime);
        //Sheep.transform.Translate(0, 0, Time.deltaTime * 2.0f);
    }
}