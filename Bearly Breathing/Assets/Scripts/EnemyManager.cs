
using UnityEngine;



public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject _sheep;
    [SerializeField] private GameObject _player;
    [SerializeField] private float spawnTime = 3f;
    [SerializeField] private Transform[] spawnPoints;

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

        Instantiate(_sheep, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
