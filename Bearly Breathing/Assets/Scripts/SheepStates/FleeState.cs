using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : ISheepState
{
    private Sheep _sheep;

    public void Enter(Sheep _sheep)
    {
        this._sheep = _sheep;
    }

    public void Execute()
    {
        _sheep.Run();
        Debug.Log("Fleeing");

        if (_sheep.distance >= 20)
        {
            _sheep.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {

    }

}

