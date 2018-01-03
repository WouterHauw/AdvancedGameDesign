﻿using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;

    // Use this for initialization
    private void Start()
    {
        var rotateVector3 = new Vector3(60, 0, 0);
        transform.Rotate(rotateVector3);
    }

    // Update is called once per frame
    private void Update()
    {
        var pos = transform.position;
        pos.x = player.transform.position.x;
        pos.z = player.transform.position.z - 3;
        pos.y = 7;
        transform.position = pos;
    }
}