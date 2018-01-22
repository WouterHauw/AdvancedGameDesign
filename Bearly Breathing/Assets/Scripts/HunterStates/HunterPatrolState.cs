using UnityEngine;

public class HunterPatrolState : IHunterState
{
    private HunterController _hunter;
    private int _currentWp;

    public void Enter(HunterController hunter)
    {
        _hunter = hunter;
        _currentWp = 0;
    }

    public void Execute()
    {
        if (_hunter.distance <= _hunter.sightRange && _hunter.player.GetComponent<PlayerController>().isHiding == false)
        {
            _hunter.ChangeState(new HunterChaseState());
            _hunter.GetAnimator().SetBool("isChasing", true);
        }
        if (_hunter.waypoints.Length == 0)
        {
            return;
        }
        if (Vector3.Distance(_hunter.waypoints[_currentWp].transform.position,
                _hunter.transform.position) < _hunter.accuracy)
        {
            _currentWp = Random.Range(0, _hunter.waypoints.Length);
            if (_currentWp >= _hunter.waypoints.Length)
            {
                _currentWp = 0;
            }
        }
        _hunter.agent.SetDestination(_hunter.waypoints[_currentWp].transform.position);
    }

    public void Exit()
    {
        _hunter.GetAnimator().SetBool("isPatroling", false);
    }
}