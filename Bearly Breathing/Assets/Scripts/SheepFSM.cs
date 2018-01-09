using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepFSM : StateMachineBehaviour {

    public GameObject npcSheep;
    public NavMeshAgent sheep;
    public NavMeshHit navHit;
    public GameObject opponent;
    public float accuracy = 3.0f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	    npcSheep = animator.transform.parent.gameObject;
        opponent = npcSheep.GetComponent<BaseNPC>().GetPlayer();
        sheep = npcSheep.GetComponent<NavMeshAgent>();
	}

}
