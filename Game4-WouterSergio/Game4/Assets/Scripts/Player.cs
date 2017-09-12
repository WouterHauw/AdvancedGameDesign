using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int _movesLeft;
    public static bool myturn;
    public int CurrentTile;
    private GameObject nextTile;
    private Color originalColor;

    public GameObject player;
    public GameObject bank;
    public Text enemyScoreText;
    public int enemyScore;

    public GameObject enemy;

    public bool onBank;
    public float distance;



    // Use this for initialization
    void Start()
    {
        
        nextTile = new GameObject();
        CurrentTile = 1;
        _movesLeft = 3;
        myturn = true;
        originalColor = GetComponent<Renderer>().material.color;

        enemyScore = 0;
        enemyScoreText.text = ("Score: ") + enemyScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (myturn)
        {
            GetComponent<Renderer>().material.color = originalColor;
            if (_movesLeft > 0)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {

                    CurrentTile += 8;
                    if (CurrentTile < 64)
                    {
                        _movesLeft -= 1;
                    }
                    else
                    {
                        CurrentTile -= 8;
                    }
                    nextTile = GameObject.Find("Tile (" + CurrentTile + ")");
                    var nextposition = nextTile.transform.position;
                    transform.position = nextposition;

                    if (EnemyMovement.CurrentTile == CurrentTile)
                    {
                        SceneManager.LoadScene("WouterScenes");
                    }
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    CurrentTile -= 8;
                    if (CurrentTile > 0)
                    {
                        _movesLeft -= 1;
                    }
                    else
                    {
                        CurrentTile += 8;
                    }
                    nextTile = GameObject.Find("Tile (" + CurrentTile + ")");
                    var nextposition = nextTile.transform.position;
                    transform.position = nextposition;

                    if (EnemyMovement.CurrentTile == CurrentTile)
                    {
                        SceneManager.LoadScene("WouterScenes");
                    }
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    CurrentTile -= 1;
                    if (CurrentTile > 0)
                    {
                        _movesLeft -= 1;
                    }
                    else
                    {
                        CurrentTile += 1;
                    }
                    nextTile = GameObject.Find("Tile (" + CurrentTile + ")");
                    var nextposition = nextTile.transform.position;
                    transform.position = nextposition;

                    if (EnemyMovement.CurrentTile == CurrentTile)
                    {
                        SceneManager.LoadScene("WouterScenes");
                    }
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    CurrentTile += 1;
                    if (CurrentTile > 0)
                    {
                        _movesLeft -= 1;
                    }
                    else
                    {
                        CurrentTile -= 1;
                    }
                    nextTile = GameObject.Find("Tile (" + CurrentTile + ")");
                    var nextposition = nextTile.transform.position;
                    transform.position = nextposition;

                    if (EnemyMovement.CurrentTile == CurrentTile)
                    {
                        SceneManager.LoadScene("WouterScenes");
                    }
                }

            }
            else
            {
                EnemyMovement._movesLeft = 2;
                myturn = false;
                GetComponent<Renderer>().material.color = Color.gray;
                EnemyMovement.myturn = true;
            }

        }

    

    }




}
