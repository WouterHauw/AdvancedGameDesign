using System;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Vector3 _cameraPosition;
    [SerializeField] private Quaternion _cameraRotation;
    [SerializeField] private float _nearClipping, _farClipping, _depth, _rotation;
    [SerializeField] private GameObject _player;

    // Use this for initialization
    private void Start()
    {
        InitializeCameraVariables();
        CameraInitialize();
    }

    // Update is called once per frame
    private void Update()
    {

        MoveCamera();
      
    }

    private void InitializeCameraVariables()
    {
        _nearClipping = 0.3f;
        _farClipping = 30f;
        _depth = -1f;
        _rotation = 45f;
        _cameraRotation = transform.rotation;
        _cameraPosition = transform.position;
    }

    //Simply set all stuff for camera, in case someone edits it in editor
    private void CameraInitialize()
    {
        Camera camera = GetComponent<Camera>();

        //fits better with our isometric view
        camera.orthographic = true;
        camera.allowMSAA = true;
        camera.allowHDR = true;

        //45 basic rotation used in Isometric view. Leave y and Z
        _cameraRotation.x = _rotation;
        //If depth is higher, that camera will be used as main camera.
        camera.depth = _depth;

        //How far camera renders, far should always be just beyond the background
        camera.nearClipPlane = _nearClipping;
        camera.farClipPlane = _farClipping;
    }

    //Number are based on feedback and tweaking
    private void MoveCamera()
    {
        //TODO:SMOOTHDAMP 
        _cameraPosition.x = _player.transform.position.x;
        _cameraPosition.y = _player.transform.position.y + 10;
        _cameraPosition.z = _player.transform.position.z - 8;
        transform.position = _cameraPosition;
    }
}