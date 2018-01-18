using UnityEngine;
using UnityEngine.AI;

public class SheepController : BaseNPC
{
    private ISheepState _currentState;

    protected override void StartNpc()
    {
        base.StartNpc();
        sightRange = 5;
        facingLeft = true;
        ChangeState(new SheepIdleState());
    }

    protected override void UpdateNpc()
    {
        base.UpdateNpc();
        distance = Vector3.Distance(transform.position, player.transform.position);
        animator.SetFloat("speed", agent.velocity.magnitude);
        animator.SetFloat("distance", distance);
        _currentState.Execute();
    }
    public void ChangeState(ISheepState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;

        _currentState.Enter(this);
    }

    private void Start()
    {
        StartNpc();
    }
    private void Update()
    {
        UpdateNpc();
    }
    
}