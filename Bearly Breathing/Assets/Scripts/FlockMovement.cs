using UnityEngine;

public class FlockMovement : MonoBehaviour
{
    private float _speed = 0.001f;
    private const float _neighbourDistance = 7.0f;
    private const float _rotationSpeed = 4.0f;
    private bool _turning;

    private void Start()
    {
        _speed = Random.Range(0.5f, 1);
    }

    private void Update()
    {
        _turning = Vector3.Distance(transform.position, Vector3.zero) >= Flocking.mapSize;
        if (_turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction),
                _rotationSpeed * Time.deltaTime);
                
            _speed = Random.Range(0.5f, 1);
        }

        if (Random.Range(0, 5) < 1)
        {
            ApplyRules();
        }

        transform.Translate(0, 0, Time.deltaTime * _speed);
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
            if (!(dist <= _neighbourDistance))
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
            gSpeed = gSpeed + anotherFlock._speed;
        }

        if (groupSize <= 0)
        {
            return;
        }
        vcentre = vcentre / groupSize + (goalPos - transform.position);
        _speed = gSpeed / groupSize;

        Vector3 direction = (vcentre + vavoid) - transform.position;
        if (direction != Vector3.zero)
        {
            direction = Vector3.zero - transform.position;
            
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction),
                _rotationSpeed * Time.deltaTime);
               
        }
    }
}