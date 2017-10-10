using System.Collections;
using System.Collections.Generic;
/**using UnityEngine;

public class IsometricCamera : MonoBehaviour {

    public GameObject player;
    public float size = 10;
    public float scrollSpeed = 30;

    Vector3 position;
    private Camera camera;

    // Use this for initialization
    void Start () {

        camera = (Camera)this.gameObject.GetComponent("Camera");
        camera.orthographic = true;
        camera.transform.rotation = Quaternion.Euler(30, 45, 0);

        position = player.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;

        float distance = 30;

       

        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(-distance, distance, -distance), 0.5f * Time.deltaTime);
        camera.transform.LookAt(player.transform);

    }
}**/
