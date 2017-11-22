using UnityEngine;

public class Scout : HunterFSM
{

    GameObject[] waypoints;
    int currentWP;

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       
        base.OnStateEnter(animator, stateInfo, layerIndex);
        opponent.GetComponent<PlayerController>().beingChased = false;
        currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hunter.speed = 15;
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentWP].transform.position,
            NPC.transform.position) < accuracy)
        {
            currentWP = Random.Range(0, waypoints.Length);
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        hunter.SetDestination(waypoints[currentWP].transform.position);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hunter.speed = 3.5f;
    }
}