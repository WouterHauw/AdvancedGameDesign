using UnityEngine;

public class FlockMovement : MonoBehaviour
{
    public float speed = 0.001f;
    private const float NeighbourDistance = 4.0f;
    private const float RotationSpeed = 4.0f;
    private bool _turning;

    private void Start()
    {
        speed = Random.Range(0.5f, 1);
    }

    private void Update()
    {
        _turning = Vector3.Distance(transform.position, Vector3.zero) >= Flocking.mapSize;
        if (_turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction),
                RotationSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }

        if (Random.Range(0, 5) < 1)
        {
            ApplyRules();
        }

        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    private void ApplyRules()
    {
        GameObject[] gos = Flocking.allSheep;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = Flocking.goalPos;

        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go == gameObject)
            {
                continue;
            }
            var dist = Vector3.Distance(go.transform.position, transform.position);
            if (!(dist <= NeighbourDistance))
            {
                continue;
            }
            vcentre += go.transform.position;
            groupSize++;

            if (dist < 10.0f)
            {
                vavoid = vavoid + (transform.position - go.transform.position);
            }

            FlockMovement anotherFlock = go.GetComponent<FlockMovement>();
            gSpeed = gSpeed + anotherFlock.speed;
        }

        if (groupSize <= 0)
        {
            return;
        }
        vcentre = vcentre / groupSize + (goalPos - transform.position);
        speed = gSpeed / groupSize;

        Vector3 direction = vcentre + vavoid - transform.position;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction),
                RotationSpeed * Time.deltaTime);
        }
    }
}