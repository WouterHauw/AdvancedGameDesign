using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DifficultyChanger : MonoBehaviour
{
    System.Random rand;
    public int hardDayNr;
    private SpawnScript _spawnScript;
    private ScoreManager _scoreManager;
    [SerializeField]
    private GameObject _player;
    private int sheepToSpawn;

    // Use this for initialization
    void Start()
    {
        InitializeVariables();
        rand = new System.Random();
    }

    void InitializeVariables()
    {
        _spawnScript = FindObjectOfType<SpawnScript>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        sheepToSpawn = 10;
        GameManager.Instance.requiredScore = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeDifficultyOnNewDay(int daysPassed)
    {
        if (daysPassed >= 5)
        {
            Debug.Log("day " + (daysPassed + 1));
            if (hardDayNr >= 4 && hardDayNr <= 6)
            {
                if (rand.Next(0, 2) == 0)
                {
                    Debug.Log("difficult day " + hardDayNr);
                    hardDayNr++;
                    DifficultDay();
                }
                else
                {
                    hardDayNr = 0;
                    RestDay();
                }

            }
            else if (hardDayNr > 6)
            {
                hardDayNr = 0;
                RestDay();
            }
            else
            {
                Debug.Log("difficult day " + hardDayNr);
                hardDayNr++;
                DifficultDay();
            }

        }
        else
        {
            switch (daysPassed)
            {
                case 0:
                    Debug.Log("day 1");
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    _scoreManager.sliderVar.maxValue = GameManager.Instance.requiredScore;
                    GameManager.Instance.health = 3;
                    break;
                case 1:
                    Debug.Log("day 2");
                    sheepToSpawn++;
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    GameManager.Instance.requiredScore++;
                    _scoreManager.sliderVar.maxValue = GameManager.Instance.requiredScore;
                    _spawnScript.SpawnHunter(1);
                    break;
                case 2:
                    Debug.Log("day 3");
                    sheepToSpawn++;
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    GameManager.Instance.requiredScore++;
                    _scoreManager.sliderVar.maxValue = GameManager.Instance.requiredScore;
                    _spawnScript.SpawnHunter(1);
                    break;
                case 3:
                    Debug.Log("day 4");
                    sheepToSpawn++;
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    GameManager.Instance.requiredScore++;
                    _scoreManager.sliderVar.maxValue = GameManager.Instance.requiredScore;
                    _spawnScript.SpawnHunter(2);
                    GameManager.Instance.health++;
                    break;
                case 4:
                    Debug.Log("day 5");
                    sheepToSpawn++;
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    GameManager.Instance.requiredScore++;
                    _scoreManager.sliderVar.maxValue = GameManager.Instance.requiredScore;
                    _spawnScript.SpawnHunter(2);
                    break;
                default:
                    break;
            }
        }
    }

    void DifficultDay()
    {
        sheepToSpawn++;
        _spawnScript.Spawnsheep(sheepToSpawn);
        GameManager.Instance.requiredScore++;
        _scoreManager.sliderVar.maxValue = GameManager.Instance.requiredScore;
        int huntersToSpawn = rand.Next(2, 9);
        _spawnScript.SpawnHunter(huntersToSpawn);
    }

    void RestDay()
    {
        GameManager.Instance.health++;
        _spawnScript.Spawnsheep(sheepToSpawn);
    }
}
