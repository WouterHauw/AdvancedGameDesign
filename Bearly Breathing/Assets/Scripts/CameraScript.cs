using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    [SerializeField] private Camera camera;
    [SerializeField] private float nearClipping, farClipping, depth, rotation;
    [SerializeField] private Quaternion cameraRotation;
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private GameObject player;

    // Use this for initialization
    void Start () {
        InitializeCameraVariables();
        CameraInitialize();
	}
	
	// Update is called once per frame
	void Update () {
        //TODO: playermovement needs to work
       // if (player.GetComponent<PlayerController>().HandleMoveInput()) { 
		    MoveCamera();
      //  }
    }

    private void InitializeCameraVariables() {
        nearClipping = 0.3f;
        farClipping = 30f;
        depth = -1f;
        rotation = 45f;
        cameraRotation = camera.transform.rotation;
        cameraPosition = camera.transform.position;
        
    }
    //Simply set all stuff for camera, in case someone edits it in editor
    private void CameraInitialize()
    {
        //fits better with our isometric view
        camera.orthographic = true;
        camera.allowMSAA = true;
        camera.allowHDR = true;
       
        //45 basic rotation used in Isometric view. Leave y and Z
        cameraRotation.x = rotation;
        //If depth is higher, that camera will be used as main camera.
        camera.depth = depth;

        //How far camera renders, far should always be just beyond the background
        camera.nearClipPlane = nearClipping ;
        camera.farClipPlane = farClipping;
    }

    //Number are based on feedback and tweaking
    private void MoveCamera()
    {
        //TODO:SMOOTHDAMP 
        cameraPosition.x = player.transform.position.x;
        cameraPosition.y = player.transform.position.y + 10;
        cameraPosition.z = player.transform.position.z -8;
        transform.position = cameraPosition;
    }
}
