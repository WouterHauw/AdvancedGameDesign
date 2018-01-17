using System.Collections.Generic;
using DigitalRubyShared;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public bool isAttacking;
    public FingersJoystickScript joystickScript;
    private bool _facingRight;
    [SerializeField] private float _minimumDistanceSwipe;
    [SerializeField] private float _minimumSpeedSwipe;
    [SerializeField] private SwipeGestureRecognizerDirection _swipeDirection;
    private SwipeGestureRecognizer _swipeGestureRecognizer;
    private Animator _anim;
    public int walkingSpeed;

    [SerializeField]
    private AudioClip _playerWalk;
    private AudioSource _audioSource;

    private static GestureTouch FirstTouch(IEnumerable<GestureTouch> touches)
    {
        foreach (var t in touches)

        {
            return t;
        }
        return new GestureTouch();
    }

    private void Awake()
    {
        joystickScript.JoystickExecuted = JoystickExecuted;
        joystickScript.MoveJoystickToGestureStartLocation = true;
        isAttacking = false;
    }


    private void Start()
    {
        _anim = GetComponent<Animator>();
        CreateSwipeGesture();

        _audioSource = GetComponent<AudioSource>();

        _swipeGestureRecognizer.MinimumDistanceUnits = _minimumDistanceSwipe;
        _swipeGestureRecognizer.MinimumSpeedUnits = _minimumSpeedSwipe;
        _swipeGestureRecognizer.Direction = _swipeDirection;
    }

    //private void TapGestureCallback(GestureRecognizer gesture, ICollection<GestureTouch> touches)
    //{
    //    if (gesture.State == GestureRecognizerState.Ended)
    //    {
    //        GestureTouch t = FirstTouch(touches);
    //        RaycastHit hit;
    //        var posRay = mainCamera.ScreenPointToRay(Input.mousePosition);
    //        Ray ray = mainCamera.ScreenPointToRay(new Vector2(t.ScreenX, t.ScreenY));
    //        if (Physics.Raycast(ray, out hit,100))
    //        {
    //            if (hit.collider != null)
    //            {
    //                Debug.Log(hit.point);
    //            }
    //        }
    //        _swipeGestureRecognizer.MinimumDistanceUnits = _minimumDistanceSwipe;
    //        _swipeGestureRecognizer.MinimumSpeedUnits = _minimumSpeedSwipe;
    //        _swipeGestureRecognizer.Direction = _swipeDirection;

    //        walkingSpeed = 8;

    //    }
    //}

    private void CreateSwipeGesture()
    {
        _swipeGestureRecognizer = new SwipeGestureRecognizer
        {
            Direction = SwipeGestureRecognizerDirection.Any,
            DirectionThreshold = 1.0f
        };
        _swipeGestureRecognizer.Updated += SwipeGestureCallback;
        FingersScript.Instance.AddGesture(_swipeGestureRecognizer);
    }

    private void SwipeGestureCallback(GestureRecognizer gesture, ICollection<GestureTouch> touches)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            isAttacking = true;
        }
    }

    private void JoystickExecuted(FingersJoystickScript script, Vector2 amount)
    {
        if (amount.x > 0 && !_facingRight)
        {
            FlipXAxis();
        }
        else if (amount.x < 0 && _facingRight)
        {
            if (amount.x > 0 && !_facingRight)
            {
                FlipXAxis();
            }
            else if (amount.x < 0 && _facingRight)
            {
                FlipXAxis();
            }
        }
        var pos = new Vector3(0,0,0);
        pos.x += amount.x * walkingSpeed * Time.deltaTime;
        pos.z += amount.y  * walkingSpeed *Time.deltaTime;
        transform.Translate(pos,Space.World);
        _anim.SetBool("isWalking", true);
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_playerWalk, 0.5f);
        }


        if (amount == Vector2.zero)
        {
            _anim.SetBool("isWalking", false);
            _audioSource.Stop();
        }
    }

    private void FlipXAxis()
    {
        //oposite direction
        _facingRight = !_facingRight;

        //get local scale
        var theScale = transform.localScale;

        //flip on x axis
        theScale.x *= -1;

        //apply that to the local scale
        transform.localScale = theScale;
    }
}