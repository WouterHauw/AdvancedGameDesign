using System.Collections.Generic;
using DigitalRubyShared;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputScript : MonoBehaviour {
        public FingersJoystickScript JoyStickScript;
        // Update is called once per frame
        public GameObject Player;

        public bool IsAttacking = false;

        public bool EnableSecondProtype;

        [SerializeField] private readonly float _smoothing = 5f;

        [SerializeField] private bool _moveJoystickToGestureStartLocation;

        private LongPressGestureRecognizer _longPressGestureRecognizer;

        private SwipeGestureRecognizer _swipeGestureRecognizer;

        private TapGestureRecognizer _pressGestureRecognizer;

        private Vector2 _moveDirection;

        private Vector2 _moveOrigin;

        private Vector2 _smoothDirection;

        private float speed = 10.0f;

        


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
            IsAttacking = false;
            if (!EnableSecondProtype)
            {
                return;
            }
            JoyStickScript.JoystickExecuted = JoystickExecuted;
            JoyStickScript.MoveJoystickToGestureStartLocation = _moveJoystickToGestureStartLocation;
        }

        //  public bool MoveJoysticktoGestureStartLocation;

        private void Start()
        {
            if (EnableSecondProtype)
            {
                CreateTapGesture();
                return;
            }
            CreateLongTapGesture();
            CreateSwipeGesture();
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
                IsAttacking = true;
            }
        }

        private void CreateTapGesture()
        {
           _pressGestureRecognizer = new TapGestureRecognizer();
            _pressGestureRecognizer.Updated += TapGestureCallback;
            FingersScript.Instance.AddGesture(_pressGestureRecognizer);
        }

        private void TapGestureCallback(GestureRecognizer gesture, ICollection<GestureTouch> touches)
        {
            if (gesture.State == GestureRecognizerState.Ended)
            {
                IsAttacking = true;
            }
        }

        public Vector2 GetDirection()
        {
            //clamp value so player won't move really fast when touch is dragged all way acroos the screen.
            _smoothDirection = Vector2.MoveTowards(_smoothDirection, _moveDirection, _smoothing);
            //return the direction the player should move
            return _smoothDirection;
        }

        private void JoystickExecuted(FingersJoystickScript script, Vector2 amount)
        {
            Vector3 pos = Player.transform.position;
            pos.x += (amount.x * speed * Time.deltaTime);
            pos.z += (amount.y * speed * Time.deltaTime);
            Vector3 faceDirection = pos - Player.transform.position;
            var step = speed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(Player.transform.forward, faceDirection, step, 0.0f);
            Player.transform.position = pos;
            Player.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}