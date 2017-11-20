using UnityEngine;

public class Chase : NPCBaseHunter {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        opponent.GetComponent<PlayerController>().beingChased = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
