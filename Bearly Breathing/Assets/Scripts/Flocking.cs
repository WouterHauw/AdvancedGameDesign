using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{

    public GameObject sheepPrefab;
    public static int mapSize = 5;
    static int numSheep = 10;
    public static GameObject[] allSheep = new GameObject[numSheep];
    public GameObject goalPrefab;
    public static Vector3 goalPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < numSheep; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-mapSize, mapSize),0,Random.Range(-mapSize, mapSize));
            allSheep[i] = (GameObject)Instantiate(sheepPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-mapSize, mapSize), 0, Random.Range(-mapSize, mapSize));
            goalPrefab.transform.position =  goalPos;
        }
    }
}
