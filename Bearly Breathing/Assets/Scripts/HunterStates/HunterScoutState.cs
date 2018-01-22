using UnityEngine;

public class HunterScoutState : IHunterState
{
    private HunterController _hunter;
    private int _currentWp;
    private float _scoutTimer;
    private float _scoutDuration = 5;

    public void Enter(HunterController hunter)
    {
        _hunter = hunter;
        _hunter.player.GetComponent<PlayerController>().beingChased = false;
        _currentWp = 0;
    }

    public void Execute()
    {
        _scoutTimer += Time.deltaTime;
        _hunter.agent.speed = 7;

        if (_hunter.distance <= _hunter.sightRange && _hunter.player.GetComponent<PlayerController>().isHiding == false)
        {
            _hunter.ChangeState(new HunterChaseState());
            _hunter.GetAnimator().SetBool("isChasing", true);
        }

        if (_scoutTimer >= _scoutDuration)
        {
            _hunter.agent.speed = 3.5f;
            _hunter.ChangeState(new HunterPatrolState());
            _hunter.GetAnimator().SetBool("isPatroling", true);
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
        _hunter.GetAnimator().SetBool("isScouting", false);
    }
}