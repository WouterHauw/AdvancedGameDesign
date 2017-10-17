using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private readonly float _speed = 6f;
    [SerializeField] private Rigidbody _rigidbody;
    [HideInInspector] public Vector3 LookDirection = Vector3.zero;
    [HideInInspector] public Vector3 MoveDirection = Vector3.zero;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //remove y
        MoveDirection.Set(MoveDirection.x, 0, MoveDirection.y);
        //move the player position
        _rigidbody.MovePosition(transform.position + MoveDirection.normalized * _speed * Time.deltaTime);

        //remove y
        LookDirection.Set(LookDirection.x, 0, LookDirection.z);
        //rotate the player to lookdirection
        _rigidbody.MoveRotation(Quaternion.LookRotation(LookDirection));
    }
}