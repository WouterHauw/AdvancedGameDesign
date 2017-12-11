﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : SheepFSM
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (opponent.transform.position.z > sheep.transform.position.z)
        {
            Vector3 runTo = (opponent.transform.position - sheep.transform.position).normalized;
            //if (NavMesh.SamplePosition(runTo, out navHit, 3.0f, NavMesh.AllAreas))
            //sheep.destination = navHit.position;
            //sheep.speed = 5;
            sheep.destination = runTo;
        }
    }
}