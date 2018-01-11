using UnityEngine;

public class SpawnScript : MonoBehaviour
{
   // [SerializeField]
    //private GameObject sheep;
    [SerializeField]
    private GameObject hunter;
    //int numToSpawn = 10;

    public void Spawnsheep(int sheepToSpawn)
    {
        int spawned = 0;

        while (spawned < sheepToSpawn)
        {
            GameObject sheep = ObjectPool.Instance.GetPooledObject();
            if (sheep != null)
            {
                Vector3 position;
                position = new Vector3(Random.Range(-50f, 50), 1, Random.Range(-50f, 50f));
                sheep.transform.position = position;
                sheep.SetActive(true);
                spawned++;
            }
        }
    }

    public void SpawnHunter(int huntersToSpawn)
    {
        int spawned = 0;

        while (spawned < huntersToSpawn)
        {
            Vector3 position;
            position = new Vector3(Random.Range(-100f, 50), 1, Random.Range(-50f, 50f));
            Instantiate(hunter, position, Quaternion.identity);
            spawned++;
        }
    }
}
