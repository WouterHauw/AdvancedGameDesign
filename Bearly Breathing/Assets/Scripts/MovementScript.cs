using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public bool SecondDemoIsPlaying = false;
    [SerializeField] private Transform movementTransform;
    [HideInInspector] public Vector3 LookDirection = Vector3.zero;
    [HideInInspector] public Vector3 MoveDirection = Vector3.zero;
    [SerializeField] private readonly float _speed = 6f;


    private void Update()
    {
        if (!SecondDemoIsPlaying)
        {
            
            movementTransform.position = new Vector3(movementTransform.position.x+ MoveDirection.x,movementTransform.position.y,movementTransform.position.z + MoveDirection.y);
            //remove y
            //MoveDirection.Set(MoveDirection.x, 0, MoveDirection.y);
            //move the player position
            //_rigidbody.MovePosition(transform.position + MoveDirection.normalized * _speed * Time.deltaTime);

            ////remove y
            //LookDirection.Set(LookDirection.x, 0, LookDirection.z);
            ////rotate the player to lookdirection
            //_rigidbody.MoveRotation(Quaternion.LookRotation(LookDirection));
        }
        
    }
}