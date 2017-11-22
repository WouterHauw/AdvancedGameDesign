using UnityEngine;

public class Patrol : HunterFSM
{
    GameObject[] waypoints;
    int currentWP;

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
        //var direction = waypoints[currentWP].transform.position - Sheep.transform.position;
        //Sheep.transform.rotation = Quaternion.Slerp(Sheep.transform.rotation,
        //                           Quaternion.LookRotation(direction),
        //                           1.0f * Time.deltaTime);
        //Sheep.transform.Translate(0, 0, Time.deltaTime * 2.0f);
    }
}
