using UnityEngine;
using UnityEngine.AI;

public class SheepFleeState : ISheepState
{
    private SheepController _sheep;
    private NavMeshHit _navHit;

    public void Enter(SheepController sheep)
    {
        this._sheep = sheep;
        _sheep.GetAnimator().SetBool("isIdle", false);
        _sheep.GetAnimator().SetBool("isEating", false);
    }

    public void Execute()
    {
        Run();

        if (_sheep.distance >= _sheep.sightRange)
        {
            _sheep.ChangeState(new SheepIdleState());
            _sheep.GetAnimator().SetBool("isIdle", true);
        }
    }

    public void Exit()
    {
        _sheep.GetAnimator().SetBool("isFleeing", false);
    }

    public void Run()
    {
        Vector3 runTo = _sheep.transform.position + (_sheep.transform.position - _sheep.player.transform.position);
        if (NavMesh.SamplePosition(runTo, out _navHit, 3.0f, NavMesh.AllAreas))
        {
            _sheep.agent.destination = _navHit.position;
            _sheep.agent.speed = 3;
        }
    }

}
