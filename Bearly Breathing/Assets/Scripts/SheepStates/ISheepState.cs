using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISheepState
{
    void Execute();
    void Enter(Sheep sheep);
    void Exit();
}
