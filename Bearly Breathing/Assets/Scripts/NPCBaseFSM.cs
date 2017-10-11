using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBaseFSM : StateMachineBehaviour {

    public GameObject NPC1;
    public NavMeshAgent sheep;
    public GameObject opponent;
    public float speed = 0.25f;
    public float rotationSpeed = 2.0f;
    public float accuracy = 3.0f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC1 = animator.gameObject;
        opponent = NPC1.GetComponent<NPC_AI>().GetPlayer();
        sheep = NPC1.GetComponent<NavMeshAgent>();
	}
}
