using UnityEngine;
using UnityEngine.AI;

public class SheepFleeState : ISheepState
{
    private SheepController _sheep;
    private NavMeshHit _navHit;

    public void Enter(SheepController sheep)
    {
        this._sheep = sheep;
    }

    public void Execute()
    {
        Run();

        if (_sheep.distance >= 15)
        {
            _sheep.ChangeState(new SheepIdleState());
        }
    }

    public void Exit()
    {

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
