using UnityEngine;
using UnityEngine.AI;

public class SheepController : BaseNPC
{
    public float distance;
    private ISheepState _currentState;

    protected override void StartNpc()
    {
        base.StartNpc();
        facingLeft = true;
        ChangeState(new IdleState());
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