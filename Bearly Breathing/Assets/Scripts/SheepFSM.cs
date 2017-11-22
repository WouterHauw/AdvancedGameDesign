using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepFSM : StateMachineBehaviour {


    public GameObject NPC1;
    public NavMeshAgent sheep;
    public GameObject opponent;
    [SerializeField]
    private float speed = 0.25f;
    [SerializeField]
    public float rotationSpeed = 2.0f;
    [SerializeField]
    public float accuracy = 3.0f;

    public GameObject sheepTransform;


	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	    NPC1 = animator.transform.parent.gameObject;
        opponent = NPC1.GetComponent<BaseNPC>().GetPlayer();
        sheep = NPC1.GetComponent<NavMeshAgent>();
	}

}
