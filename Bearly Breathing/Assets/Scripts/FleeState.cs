using UnityEngine;
using UnityEngine.AI;

public class FleeState : ISheepState
{
    private SheepController _sheep;
    private NavMeshHit _navHit;

    public void Enter(SheepController _sheep)
    {
        this._sheep = _sheep;
        _sheep.GetAnimator().SetBool("isIdle", false);
        _sheep.GetAnimator().SetBool("isEating", false);
    }

    public void Execute()
    {
        Run();

        if (_sheep.distance >= 20)
        {
            _sheep.ChangeState(new IdleState());
            _sheep.GetAnimator().SetBool("isIdle", true);
        }
    }

    public void Exit()
    {
        _sheep.GetAnimator().SetBool("isFleeing", false);
    }

    public void Run()
    {
        Vector3 runTo = _sheep.transform.position + (_sheep.transform.position - _sheep.GetPlayer().transform.position);
        if (NavMesh.SamplePosition(runTo, out _navHit, 3.0f, NavMesh.AllAreas))
        {
            _sheep.GetAgent().destination = _navHit.position;
            _sheep.GetAgent().speed = 3;
        }
    }

}
