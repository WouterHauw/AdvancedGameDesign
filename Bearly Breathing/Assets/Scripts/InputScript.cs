using System.Collections.Generic;
using DigitalRubyShared;
using UnityEngine;
//using UnityEngine.VR.WSA;

namespace Assets.Scripts
{
    public class InputScript : MonoBehaviour
    {
        public FingersJoystickScript joystickScript;
        [SerializeField] private float _minimumDistanceSwipe;
        [SerializeField] private float _minimumSpeedSwipe;
        [SerializeField] private SwipeGestureRecognizerDirection _swipeDirection;
        public GameObject player;
        public bool isAttacking;
        private TapGestureRecognizer _pressGestureRecognizer;
        private Vector2 _smoothDirection;
        private SwipeGestureRecognizer _swipeGestureRecognizer;
        private LongPressGestureRecognizer _longPressGestureRecognizer;
        private bool _facingRight = false;
        private Animator anim;
        public int walkingSpeed;


        private GestureTouch FirstTouch(ICollection<GestureTouch> touches)
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
            joystickScript.MoveJoystickToGestureStartLocation = false; 
            isAttacking = false;
        }

        //  public bool MoveJoysticktoGestureStartLocation;

        private void Start()
        {
            anim = player.GetComponentInChildren<Animator>();
            CreateSwipeGesture();

            _swipeGestureRecognizer.MinimumDistanceUnits = _minimumDistanceSwipe;
            _swipeGestureRecognizer.MinimumSpeedUnits = _minimumSpeedSwipe;
            _swipeGestureRecognizer.Direction = _swipeDirection;

            walkingSpeed = 8;
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
            Vector3 pos = player.transform.position;
            pos.x += (amount.x * walkingSpeed * Time.deltaTime);
            pos.z += (amount.y * walkingSpeed * Time.deltaTime);
            player.transform.position = pos;
            anim.SetBool("isWalking", true);

            if (amount == Vector2.zero)
            {
                anim.SetBool("isWalking", false);
            }
        }

        private void FlipXAxis()
        {
            //oposite direction
            _facingRight = !_facingRight;

            //get local scale
            var theScale = player.transform.localScale;

            //flip on x axis
            theScale.x *= -1;

            //apply that to the local scale
            player.transform.localScale = theScale;
        }

    }
}