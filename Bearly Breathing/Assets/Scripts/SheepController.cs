using UnityEngine;
using UnityEngine.AI;

public class SheepController : BaseNPC
{
    private ISheepState _currentState;

    protected override void StartNpc()
    {
        base.StartNpc();
        facingLeft = true;
        ChangeState(new SheepIdleState());
    }

    protected override void UpdateNpc()
    {
        base.UpdateNpc();
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