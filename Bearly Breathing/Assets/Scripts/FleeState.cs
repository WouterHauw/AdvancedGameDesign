using UnityEngine;
using UnityEngine.AI;

public class FleeState : ISheepState
{
    private SheepController _sheep;
    private NavMeshHit _navHit;

    public void Enter(SheepController _sheep)
    {
        this._sheep = _sheep;
    }

    public void Execute()
    {
        Run();

        if (_sheep.distance >= 15)
        {
            _sheep.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {

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
