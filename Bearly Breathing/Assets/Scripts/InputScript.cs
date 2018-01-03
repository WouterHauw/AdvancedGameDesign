using System.Collections.Generic;
using DigitalRubyShared;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    public bool isAttacking;
    public FingersJoystickScript joystickScript;
    private bool _facingRight;
    [SerializeField] private float _minimumDistanceSwipe;
    [SerializeField] private float _minimumSpeedSwipe;
    [SerializeField] private SwipeGestureRecognizerDirection _swipeDirection;
    private SwipeGestureRecognizer _swipeGestureRecognizer;
    private Animator _anim;


    private GestureTouch FirstTouch(IEnumerable<GestureTouch> touches)
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

    //  public bool MoveJoysticktoGestureStartLocation;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        CreateSwipeGesture();

        _swipeGestureRecognizer.MinimumDistanceUnits = _minimumDistanceSwipe;
        _swipeGestureRecognizer.MinimumSpeedUnits = _minimumSpeedSwipe;
        _swipeGestureRecognizer.Direction = _swipeDirection;
    }

    private void Update()
    {
        _swipeGestureRecognizer.MinimumDistanceUnits = _minimumDistanceSwipe;
        _swipeGestureRecognizer.MinimumSpeedUnits = _minimumSpeedSwipe;
        _swipeGestureRecognizer.Direction = _swipeDirection;
    }

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
            FlipXAxis();
        }
        var pos = transform.position;
        pos.x += amount.x * 8 * Time.deltaTime;
        pos.z += amount.y * 8 * Time.deltaTime;
        transform.position = pos;
        _anim.SetBool("isWalking", true);

        if (amount == Vector2.zero)
        {
            _anim.SetBool("isWalking", false);
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