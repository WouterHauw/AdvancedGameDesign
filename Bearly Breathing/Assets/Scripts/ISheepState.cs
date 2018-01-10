using UnityEngine;

public interface ISheepState
{
    void Enter(Sheep sheep);
    void Execute();
    void Exit();
}

