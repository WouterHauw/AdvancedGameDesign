using UnityEngine;

public class IdleState : ISheepState
{
    private Sheep _sheep;
    private float _eatTimer;
    private float _idleTimer;
    private float _idleDuration = 10;
    private float _eatDuration = 5;

    public void Enter(Sheep _sheep)
    {
        this._sheep = _sheep;
    }

    public void Execute()
    {
        _sheep.sheepAgent.isStopped = true;

        Idle();

        if (_sheep.distance <= 20)
        {
            _sheep.ChangeState(new FleeState());
            _sheep.anim.SetBool("isFleeing", true);
        }
    }

    public void Exit()
    {
        _sheep.sheepAgent.isStopped = false;
        _sheep.anim.SetBool("isIdle", false);
    }

    private void Idle()
    {
        _sheep.sheepAgent.isStopped = true;
        
        _idleTimer += Time.deltaTime;
        _sheep.anim.SetBool("isEating", true);

        if (_eatTimer >= _eatDuration)
            _sheep.anim.SetBool("isEating", false);

        if (_idleTimer >= _idleDuration)
        {
            _sheep.anim.SetBool("isEating", false);
            _sheep.ChangeState(new WalkState());
            _sheep.anim.SetBool("isWalking", true);
        }
    }
}

