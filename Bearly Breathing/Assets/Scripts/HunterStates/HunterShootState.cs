﻿

public class HunterShootState : IHunterState
{
    private HunterController _hunter;

    public void Enter(HunterController hunter)
    {
        _hunter = hunter;
        _hunter.GetComponent<HunterController>().StartFiring();
    }

    public void Execute()
    {
        if (_hunter.distance >= _hunter.shootRange)
        {
            _hunter.ChangeState(new HunterChaseState());
        }
    }

    public void Exit()
    {
        _hunter.GetComponent<HunterController>().StopFiring();
    }
}