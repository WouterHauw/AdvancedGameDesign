using UnityEngine;
using UnityEngine.AI;

public class HunterFSM : StateMachineBehaviour
{
    public GameObject NPCHunter;
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
        NPCHunter = animator.transform.gameObject;
        opponent = NPCHunter.GetComponent<BaseNPC>().GetPlayer();
        hunter = NPCHunter.GetComponentInParent<NavMeshAgent>();
        distance = Vector3.Distance(NPCHunter.transform.position, opponent.transform.position);
        isHiding = opponent.GetComponent<PlayerController>().isHiding;
    }
}
