﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraMovement : MonoBehaviour
{

    public float dragSpeed = 2;
    private Vector3 dragOrigin;

	void LateUpdate () {
	    if (Input.GetMouseButtonDown(0))
	    {
	        dragOrigin = Input.mousePosition;
            return;
	    }
	    if (!Input.GetMouseButton(0)) return;

	    Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

        transform.Translate(move,Space.World);
	}
}
