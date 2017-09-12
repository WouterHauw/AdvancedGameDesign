using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static int _movesLeft;
    public static bool myturn;
    public static int CurrentTile;
    private GameObject nextTile;
    

    void Start () {
        nextTile = new GameObject();
        CurrentTile = 64;
        _movesLeft = 2;
        myturn = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if (myturn)
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
	        else
	        {
	            Player._movesLeft = 3;
	            myturn = false;
	            Player.myturn = true;
	        }
	    }


	}
}

