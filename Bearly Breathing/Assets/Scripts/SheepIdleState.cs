using UnityEngine;

public class SheepIdleState : ISheepState
{
    private SheepController _sheep;
    private float _idleTimer;
    private float _idleDuration = 10;

    public void Enter(SheepController sheep)
    {
        _sheep = sheep;
    }

    public void Execute()
    {
        _sheep.agent.isStopped = true;

        Idle();

        if (_sheep.distance <= 20)
        {
            _sheep.ChangeState(new SheepFleeState());
        }
    }

    public void Exit()
    {
        _sheep.agent.isStopped = false;
    }

    private void Idle()
    {
        _sheep.agent.isStopped = true;

        _idleTimer += Time.deltaTime;

        if (_idleTimer >= _idleDuration)
        {
            _sheep.ChangeState(new SheepWalkState());
        }
    }
}

