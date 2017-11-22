using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject _sheep;
    [SerializeField] private GameObject _player;
    [SerializeField] private float spawnTime = 3;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int _sheepCount = 0;
    
    private int _maxSheep = 5;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (_player == null)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if (_sheepCount >= _maxSheep)
        {
            CancelInvoke("Spawn");
        }

        if (_sheepCount < _maxSheep)
        {
            Instantiate(_sheep, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
            _sheepCount++;
        }
    }
}
