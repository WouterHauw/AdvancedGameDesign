using UnityEngine;

public class IdleState : ISheepState
{
    private SheepController _sheep;
    private float _idleTimer;
    private float _idleDuration = 10;

    public void Enter(SheepController _sheep)
    {
        this._sheep = _sheep;
    }

    public void Execute()
    {
        _sheep.GetAgent().isStopped = true;

        Idle();

        if (_sheep.distance <= 20)
        {
            _sheep.ChangeState(new FleeState());
        }
    }

    public void Exit()
    {
        _sheep.GetAgent().isStopped = false;
    }

    private void Idle()
    {
        _sheep.GetAgent().isStopped = true;

        _idleTimer += Time.deltaTime;

        if (_idleTimer >= _idleDuration)
        {
            _sheep.ChangeState(new WalkState());
        }
    }
}

