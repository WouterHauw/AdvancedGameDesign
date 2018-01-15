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
        _sheep.GetAnimator().SetBool("isIdle", false);
        _sheep.GetAnimator().SetBool("isEating", false);
    }

    public void Execute()
    {
        Walk();

        Move();

        if (_sheep.distance <= _sheep.sightRange)
        {
            _sheep.ChangeState(new SheepFleeState());
            _sheep.GetAnimator().SetBool("isFleeing", true);
        }

    }

    public void Exit()
    {
        _sheep.GetAnimator().SetBool("isWalking", false);
    }

    private void Walk()
    {
        _walkTimer += Time.deltaTime;

        if (_walkTimer >= _walkDuration)
        {
            _sheep.ChangeState(new SheepIdleState());
            _sheep.GetAnimator().SetBool("isIdle", true);
        }
    }

    private void Move()
    {
        // Chooses a random destination in a certain radius
        if (Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
            _sheep.agent.destination = goalPos;


            if(_sheep.GetAnimator().velocity.magnitude > 0)
                _sheep.GetAnimator().SetBool("isWalking", true);

        }
    }

}

