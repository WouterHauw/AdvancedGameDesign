using UnityEngine;
using UnityEngine.AI;

public class HunterFSM : StateMachineBehaviour
{
    public static float distance;

    [SerializeField] public float accuracy = 3.0f;

    public NavMeshAgent hunter;
    public bool isHiding;
    public GameObject npcHunter;
    public GameObject opponent;

    [SerializeField] public float rotationSpeed = 2.0f;

    public float speed = 0.25f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npcHunter = animator.transform.parent.gameObject;
        opponent = npcHunter.GetComponent<BaseNPC>().GetPlayer();
        hunter = npcHunter.GetComponent<NavMeshAgent>();
        distance = Vector3.Distance(npcHunter.transform.position, opponent.transform.position);
        isHiding = opponent.GetComponent<PlayerController>().isHiding;
    }
}