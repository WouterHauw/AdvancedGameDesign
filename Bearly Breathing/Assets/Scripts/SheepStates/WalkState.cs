using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : ISheepState
{
    private Sheep _sheep;
    private float _walkTimer;
    private float _walkDuration = 5;

    public void Enter(Sheep _sheep)
    {
        this._sheep = _sheep;
        _sheep.currentWP = 0;
    }

    public void Execute()
    {
        Walk();

        _sheep.Move();

        Debug.Log("Moving");
    }

    public void Exit()
    {

    }

    private void Walk()
    {
        _walkTimer += Time.deltaTime;

        if (_walkTimer >= _walkDuration)
        {
            _sheep.ChangeState(new IdleState());
        }
    }

}
