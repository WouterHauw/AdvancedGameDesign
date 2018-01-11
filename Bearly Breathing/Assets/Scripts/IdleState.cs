using UnityEngine;

public class IdleState : ISheepState
{
    private SheepController _sheep;
    private float _idleTimer;
    private float _idleDuration = 10;
    private float _eatTimer;
    private float _eatDuration = 5;

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
            _sheep.GetAnimator().SetBool("isFleeing", true);
        }
    }

    public void Exit()
    {
        _sheep.GetAgent().isStopped = false;
        _sheep.GetAnimator().SetBool("isIdle", false);
    }

    private void Idle()
    {
        _sheep.GetAgent().isStopped = true;

        _idleTimer += Time.deltaTime;
        _sheep.GetAnimator().SetBool("isEating", true);

        if (_eatTimer >= _eatDuration)
            _sheep.GetAnimator().SetBool("isEating", false);

        if (_idleTimer >= _idleDuration)
        {
            _sheep.GetAnimator().SetBool("isEating", false);
            _sheep.ChangeState(new WalkState());
            _sheep.GetAnimator().SetBool("isWalking", true);
        }
    }
}

