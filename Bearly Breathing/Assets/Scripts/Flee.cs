using UnityEngine;
using UnityEngine.AI;

public class Flee : SheepFSM
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var runTo = sheep.transform.position + (sheep.transform.position - opponent.transform.position);
        if (!NavMesh.SamplePosition(runTo, out navHit, 3.0f, NavMesh.AllAreas))
        {
            return;
        }
        sheep.destination = navHit.position;
        sheep.speed = 5;
        //sheep.SetDestination(runTo);
    }
}