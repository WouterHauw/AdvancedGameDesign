using System.Collections.Generic;
using DigitalRubyShared;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputScript : MonoBehaviour
    {
        [SerializeField] private float _minimumDurationLongTap;

        [SerializeField] private float _thresholdUnits;

        [SerializeField] private float _minimumDistanceSwipe;

        [SerializeField] private float _minimumSpeedSwipe;

        [SerializeField] private SwipeGestureRecognizerDirection _swipeDirection;

        public bool isAttacking;

        [SerializeField] private bool _firstTouchTime;

        private Vector2 _moveDirection;

        private Vector2 _moveOrigin;

        private TapGestureRecognizer _pressGestureRecognizer;

        private Vector2 _smoothDirection;

        [SerializeField] private readonly float _smoothing = 5f;

        private SwipeGestureRecognizer _swipeGestureRecognizer;

        private LongPressGestureRecognizer _longPressGestureRecognizer;



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
            _moveDirection = Vector2.zero;
            _moveOrigin = Vector2.zero;
            isAttacking = false;
            _firstTouchTime = false;
        }

        //  public bool MoveJoysticktoGestureStartLocation;

        private void Start()
        {
            CreateTapGesture();
            CreateSwipeGesture();
        }

        private void Update()
        {
            _longPressGestureRecognizer.MinimumDurationSeconds = _minimumDurationLongTap;
            _longPressGestureRecognizer.ThresholdUnits = _thresholdUnits;

            _swipeGestureRecognizer.MinimumDistanceUnits = _minimumDistanceSwipe;
            _swipeGestureRecognizer.MinimumSpeedUnits = _minimumSpeedSwipe;
            _swipeGestureRecognizer.Direction = _swipeDirection;


        }


        private void CreateLongTapGesture()
        {
            _longPressGestureRecognizer = new LongPressGestureRecognizer();
            _longPressGestureRecognizer.Updated += LongPressLongGestureCallback;
            FingersScript.Instance.AddGesture(_longPressGestureRecognizer);
        }

        private void LongPressLongGestureCallback(GestureRecognizer gesture, ICollection<GestureTouch> touches)
        {
            var t = FirstTouch(touches);
            //when touch begin set the origin of touch
            if (gesture.State == GestureRecognizerState.Began)
            {
                _moveOrigin = new Vector2(t.X, t.Y);
            }
            //when touch is executing is compare origin of touch with new position of touch
            if (gesture.State == GestureRecognizerState.Executing)
            {
                var currentposition = new Vector2(t.X, t.Y);
                var directionVectorRaw = currentposition - _moveOrigin;
                _moveDirection = directionVectorRaw.normalized;
            }
            //when touch end set the move direction to zero
            if (gesture.State == GestureRecognizerState.Ended)
            {
                _moveDirection = Vector2.zero;
            }
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

        private void CreateTapGesture()
        {
            _pressGestureRecognizer = new TapGestureRecognizer()
            {
                

            };
            _pressGestureRecognizer.Updated += TapGestureCallback;
            FingersScript.Instance.AddGesture(_pressGestureRecognizer);
        }

        private void TapGestureCallback(GestureRecognizer gesture, ICollection<GestureTouch> touches)
        {
            var t = FirstTouch(touches);
            //when touch begin set the origin of touch
            if (gesture.State == GestureRecognizerState.Began)
            {
                _moveOrigin = new Vector2(t.X, t.Y);
            }
            //when touch is executing is compare origin of touch with new position of touch
            if (gesture.State == GestureRecognizerState.Executing)
            {
                var currentposition = new Vector2(t.X, t.Y);
                var directionVectorRaw = currentposition - _moveOrigin;
                _moveDirection = directionVectorRaw.normalized;
            }
            //when touch end set the move direction to zero
            if (gesture.State == GestureRecognizerState.Ended)
            {
                _moveDirection = Vector2.zero;
            }
        }

        public Vector2 GetDirection()
        {
            //clamp value so player won't move really fast when touch is dragged all way acroos the screen.
            _smoothDirection = Vector2.MoveTowards(_smoothDirection, _moveDirection, _smoothing);
            //return the direction the player should move
            return _smoothDirection;
        }

    }
}