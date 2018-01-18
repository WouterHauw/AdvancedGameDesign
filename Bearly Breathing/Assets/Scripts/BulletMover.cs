using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{

    [SerializeField]
    private float maxSpeed = 30;

    void Update()
    {

        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(maxSpeed * Time.deltaTime, 0, 0);

        if (transform.localRotation.z > 0)
        {
            pos += transform.rotation * -velocity;

            transform.position = pos;
        }

        else
        {
            pos += transform.rotation * velocity;

            transform.position = pos;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
