public class HunterChaseState : IHunterState
{
    private int _currentWp;
    private HunterController _hunter;

    public void Enter(HunterController hunter)
    {
        _hunter = hunter;
        _hunter.player.GetComponent<PlayerController>().beingChased = true;
    }

    public void Execute()
    {
        if (_hunter.distance >= _hunter.sightRange)
        {
            _hunter.ChangeState(new HunterScoutState());
        }
        if (_hunter.distance >= _hunter.shootRange)
        {
            _hunter.agent.SetDestination(_hunter.player.transform.position);
        }
        else
        {
            _hunter.agent.isStopped = true; //hunter stops chasing when near the player
            _hunter.agent.ResetPath();
            _hunter.ChangeState(new HunterShootState());
        }
    }

    public void Exit() { }
}