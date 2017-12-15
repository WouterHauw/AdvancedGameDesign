using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ISheepState
{
    private Sheep _sheep;
    private float _idleTimer;
    private float _idleDuration = 10;

    public void Enter(Sheep _sheep)
    {
        this._sheep = _sheep;
    }

    public void Execute()
    {

        _sheep.sheepAgent.isStopped = true;

        Debug.Log("Idle");

        Idle();

        if(_sheep.distance <= 20)
        {
            _sheep.ChangeState(new FleeState());
        }


    }

    public void Exit()
    {
        _sheep.sheepAgent.isStopped = false;
    }

    private void Idle()
    {
        _sheep.sheepAgent.isStopped = true;

        _idleTimer += Time.deltaTime;

        if(_idleTimer >= _idleDuration)
        {
            _sheep.ChangeState(new WalkState());
        }
    }

}
