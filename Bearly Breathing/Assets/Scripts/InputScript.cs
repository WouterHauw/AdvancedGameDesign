using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    public class InputScript : MonoBehaviour {



        //public FingersJoystickScript joyStickScript;
        private TapGestureRecognizer tapGesture;
        private SwipeGestureRecognizer swipeGesture;

        // Update is called once per frame
        public GameObject player;
        private Camera camera;
        private GestureTouch t;
        public float speed = 10.0f;
       // private Vector2 newPosition;
        Vector3 inWorldPosition;

        private GestureTouch FirstTouch(ICollection<GestureTouch> touches)
        {
            foreach(GestureTouch t in touches)
            {
                return t;
            }
            return new GestureTouch();
        }

      //  public bool MoveJoysticktoGestureStartLocation;

        public void Start()
        {
            CreateTapGesture();
            camera = Camera.main;
        }

        public void Update()
        {
            player.transform.position = inWorldPosition;
              //  player.transform.position = Vector3.MoveTowards(player.transform.position, inWorldPosition, speed * Time.deltaTime);
            

        }

        private void CreateTapGesture()
        {
            tapGesture = new TapGestureRecognizer();
            tapGesture.Updated += TapGestureCallback;
            FingersScript.Instance.AddGesture(tapGesture);
        }

        protected void TapGestureCallback(GestureRecognizer gesture, ICollection<GestureTouch> touches)
        {
            if (gesture.State == GestureRecognizerState.Ended) {
                 t = FirstTouch(touches);
                Debug.Log("the update tap  = " + t.X + ", Y: " + t.Y);
              
                inWorldPosition = camera.ScreenToWorldPoint(new Vector3(t.X, t.Y, camera.nearClipPlane));
                inWorldPosition.y = 0;
                Debug.Log("Where he actually goes = " + inWorldPosition);
            }
         
        }        

        private void Awake()
        {
           // joyStickScript.JoystickExecuted = joystickExecuted;
           // joyStickScript.MoveJoystickToGestureStartLocation = MoveJoysticktoGestureStartLocation;
        }

        /**private void joystickExecuted(FingersJoystickScript script, Vector2 amount)
        {
            Vector3 pos = player.transform.position;
            pos.x += (amount.x * speed * Time.deltaTime);
            pos.z += (amount.y * speed * Time.deltaTime);
            Vector3 faceDirection = pos - player.transform.position;
            var step = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(player.transform.forward, faceDirection, step, 0.0f);
            player.transform.position = pos;
            player.transform.rotation = Quaternion.LookRotation(newDirection);
            


        }**/
    }
}