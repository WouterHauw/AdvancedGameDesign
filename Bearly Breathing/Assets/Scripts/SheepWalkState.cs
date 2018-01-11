using Random = UnityEngine.Random;
using UnityEngine;

public class SheepWalkState : ISheepState
{
    private SheepController _sheep;
    private float _walkTimer;
    private float _walkDuration = 5;

    public static int radius = 2;
    public static Vector3 goalPos = Vector3.zero;

    public void Enter(SheepController sheep)
    {
        _sheep = sheep;
    }

    public void Execute()
    {
        Walk();

        Move();

        if (_sheep.distance <= 20)
        {
            _sheep.ChangeState(new SheepFleeState());
        }

    }

    public void Exit()
    {

    }

    private void Walk()
    {
        _walkTimer += Time.deltaTime;

        if (_walkTimer >= _walkDuration)
        {
            _sheep.ChangeState(new SheepIdleState());
        }
    }

    private void Move()
    {
        // Chooses a random destination in a certain radius
        if (Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
            _sheep.agent.destination = goalPos;
        }
    }

}

