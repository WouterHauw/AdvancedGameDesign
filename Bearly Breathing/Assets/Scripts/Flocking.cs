using UnityEngine;

public class Flocking : MonoBehaviour
{
    public static int mapSize = 5;
    private const int NumSheep = 10;
    public static GameObject[] allSheep = new GameObject[NumSheep];
    public static Vector3 goalPos = Vector3.zero;
    public GameObject goalPrefab;

    public GameObject sheepPrefab;

    // Use this for initialization
    private void Start()
    {
        for (var i = 0; i < NumSheep; i++)
        {
            var pos = new Vector3(Random.Range(-mapSize, mapSize), 0, Random.Range(-mapSize, mapSize));
            allSheep[i] = Instantiate(sheepPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Random.Range(0, 10000) >= 50)
        {
            return;
        }
        goalPos = new Vector3(Random.Range(-mapSize, mapSize), 0, Random.Range(-mapSize, mapSize));
        goalPrefab.transform.position = goalPos;
    }
}