using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int CurrentTile;
    private int[] _possibleMoves;
    private GameObject nextTile;
    private int _movesLeft;



    // Use this for initialization
    void Start()
    {
        _possibleMoves = new int[4];
        nextTile = new GameObject();
        CurrentTile = 1;
        _movesLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
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
            }
            
        }



    }
}
