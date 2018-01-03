using UnityEngine;

public class Chase : HunterFSM
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        opponent.GetComponent<PlayerController>().beingChased = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (distance >= 10.0f)
        {
            hunter.SetDestination(opponent.transform.position);
        }

        else
        {
            hunter.isStopped = true; //hunter stops chasing when near the player
            hunter.ResetPath();
        }
    }
}