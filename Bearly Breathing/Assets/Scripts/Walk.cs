using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : NPCBaseFSM
{
    //private NavMeshAgent nav;
    GameObject[] waypoints;
    int currentWP;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        //sheep = FindObjectOfType<Animator>().gameObject.GetComponentInParent<NavMeshAgent>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator,stateInfo,layerIndex);
        currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentWP].transform.position,
            NPC1.transform.position) < 3.0f)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        sheep.SetDestination(waypoints[currentWP].transform.position);
        //var direction = waypoints[currentWP].transform.position - Sheep.transform.position;
        //Sheep.transform.rotation = Quaternion.Slerp(Sheep.transform.rotation,
        //                           Quaternion.LookRotation(direction),
        //                           1.0f * Time.deltaTime);
        //Sheep.transform.Translate(0, 0, Time.deltaTime * 2.0f);
    }
}
