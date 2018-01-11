using UnityEngine;

public class SheepIdleState : ISheepState
{
    private SheepController _sheep;
    private float _idleTimer;
    private float _idleDuration = 10;
    private float _eatTimer;
    private float _eatDuration = 5;

    public void Enter(SheepController sheep)
    {
        _sheep = sheep;
    }

    public void Execute()
    {
        _sheep.agent.isStopped = true;

        Idle();

        if (_sheep.distance <= _sheep.sightRange)
        {
            _sheep.ChangeState(new SheepFleeState());
            _sheep.GetAnimator().SetBool("isFleeing", true);
        }
    }

    public void Exit()
    {
        _sheep.agent.isStopped = false;
        _sheep.GetAnimator().SetBool("isIdle", false);
    }

    private void Idle()
    {
        _sheep.agent.isStopped = true;

        _idleTimer += Time.deltaTime;
        _sheep.GetAnimator().SetBool("isEating", true);

        if (_eatTimer >= _eatDuration)
            _sheep.GetAnimator().SetBool("isEating", false);

        if (_idleTimer >= _idleDuration)
        {
            _sheep.GetAnimator().SetBool("isEating", false);
            _sheep.ChangeState(new SheepWalkState());
            _sheep.GetAnimator().SetBool("isWalking", true);
        }
    }
}

