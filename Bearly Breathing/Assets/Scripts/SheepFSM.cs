using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepFSM : StateMachineBehaviour {

    public GameObject NPCSheep;
    public NavMeshAgent sheep;
    public NavMeshHit navHit;
    public GameObject opponent;
    public float _accuracy = 3.0f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	    NPCSheep = animator.transform.parent.gameObject;
        opponent = NPCSheep.GetComponent<BaseNPC>().GetPlayer();
        sheep = NPCSheep.GetComponent<NavMeshAgent>();
	}

}
