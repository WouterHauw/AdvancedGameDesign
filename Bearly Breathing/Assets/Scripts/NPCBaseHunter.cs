using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBaseHunter : StateMachineBehaviour
{

    public GameObject NPC;
    public NavMeshAgent hunter;
    public GameObject opponent;
    public float speed = 0.25f;
    public float rotationSpeed = 2.0f;
    public float accuracy = 3.0f;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        opponent = NPC.GetComponent<NPC_AI>().GetPlayer();
        hunter = NPC.GetComponent<NavMeshAgent>();
    }
}
