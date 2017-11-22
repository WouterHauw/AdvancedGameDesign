using UnityEngine;
using UnityEngine.AI;

public class HunterFSM : StateMachineBehaviour
{
    public GameObject NPC;
    public NavMeshAgent hunter;
    public GameObject opponent;
    public float speed = 0.25f;
    [SerializeField]
    public float rotationSpeed = 2.0f;
    [SerializeField]
    public float accuracy = 3.0f;

    public static float distance;
    public bool isHiding;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        opponent = NPC.GetComponent<BaseNPC>().GetPlayer();
        hunter = NPC.GetComponent<NavMeshAgent>();
        distance = Vector3.Distance(NPC.transform.position, opponent.transform.position);
        isHiding = opponent.GetComponent<PlayerController>().isHiding;
    }
}
