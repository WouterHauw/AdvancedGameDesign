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
        sheepToSpawn = 50;
        GameManager.Instance.requiredScore = 5;
    }

    public void ChangeDifficultyOnNewDay(int daysPassed)
    {
        if (daysPassed >= 5)
        {
            if (hardDayNr >= 4 && hardDayNr <= 6)
            {
                if (rand.Next(0, 2) == 0)
                {
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
                hardDayNr++;
                DifficultDay();
            }

        }
        else
        {
            switch (daysPassed)
            {
                case 0:
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    GameManager.Instance.health = 3;
                    break;
                case 1:
                    sheepToSpawn++;
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    GameManager.Instance.requiredScore++;
                    _spawnScript.SpawnHunter(1);
                    break;
                case 2:
                    sheepToSpawn++;
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    GameManager.Instance.requiredScore++;
                    _spawnScript.SpawnHunter(1);
                    break;
                case 3:
                    sheepToSpawn++;
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    GameManager.Instance.requiredScore++;
                    _spawnScript.SpawnHunter(2);
                    GameManager.Instance.health++;
                    break;
                case 4:
                    sheepToSpawn++;
                    _spawnScript.Spawnsheep(sheepToSpawn);
                    GameManager.Instance.requiredScore++;
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
        int huntersToSpawn = rand.Next(2, 9);
        _spawnScript.SpawnHunter(huntersToSpawn);
    }

    void RestDay()
    {
        GameManager.Instance.health++;
        _spawnScript.Spawnsheep(sheepToSpawn);
    }
}
