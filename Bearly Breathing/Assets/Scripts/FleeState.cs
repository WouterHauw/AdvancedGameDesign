using UnityEngine;
using UnityEngine.AI;

public class FleeState : ISheepState
{
    private Sheep _sheep;
    private NavMeshHit _navHit;

    public void Enter(Sheep _sheep)
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
        Vector3 runTo = _sheep.sheepTransform.position + (_sheep.sheepTransform.position - _sheep.playerTransform.position);
        if (NavMesh.SamplePosition(runTo, out _navHit, 3.0f, NavMesh.AllAreas))
        {
            _sheep.sheepAgent.destination = _navHit.position;
            _sheep.sheepAgent.speed = 3;
        }
    }

}
