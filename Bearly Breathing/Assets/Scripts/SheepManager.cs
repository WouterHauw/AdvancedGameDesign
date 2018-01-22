using UnityEngine;

public class SheepManager : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] _animatorcontroller;
    private const int MaxSheep = 10;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _sheep;
    [SerializeField] private int _sheepCount;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTime = 3;

    private void Start()
    {
        InvokeRepeating("Spawn", _spawnTime, _spawnTime);
    }

    private void Spawn()
    {
        if (_player == null)
        {
            return;
        }

        var spawnPointIndex = Random.Range(0, _spawnPoints.Length);

        if (_sheepCount >= MaxSheep)
        {
            CancelInvoke("Spawn");
        }

        if (_sheepCount >= MaxSheep)
        {
            return;
        }
        var sheep = Instantiate(_sheep, _spawnPoints[spawnPointIndex].transform.position,
            _spawnPoints[spawnPointIndex].transform.rotation);
        var randomNumber = Random.Range(0, _animatorcontroller.Length);
        sheep.gameObject.GetComponentInChildren<Animator>().runtimeAnimatorController =
            _animatorcontroller[randomNumber];
        _sheepCount++;
    }
}