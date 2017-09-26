using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : StateMachineBehaviour {

    GameObject Sheep;
    GameObject[] waypoints;
    int currentWP;

    private AudioSource audio;

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Sheep = animator.gameObject;
        currentWP = 0;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (waypoints.Length == 0) return;
        if(Vector3.Distance(waypoints[currentWP].transform.position,
            Sheep.transform.position) < 3.0f)
        {
            currentWP++;
            if(currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        var direction = waypoints[currentWP].transform.position - Sheep.transform.position;
        Sheep.transform.rotation = Quaternion.Slerp(Sheep.transform.rotation,
                                   Quaternion.LookRotation(direction),
                                   1.0f * Time.deltaTime);
        Sheep.transform.Translate(0, 0, Time.deltaTime * 2.0f);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}
}
