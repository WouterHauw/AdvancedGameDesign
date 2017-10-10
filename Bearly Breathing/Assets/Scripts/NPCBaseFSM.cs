using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {

    public GameObject Sheep;
    public UnityEngine.AI.NavMeshAgent agent;
    public float speed = 0.25f;
    public float rotationSpeed = 10.0f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Sheep = animator.gameObject;
        agent = Sheep.GetComponent<UnityEngine.AI.NavMeshAgent>();
            
	}
}
