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
        private Ray ray;
        private Camera camera;
        private float enter ;
        private Vector3 playerPos;
        private Vector3 point;
        private Vector3 targetPos;
        private Vector2 playerCameraPos;
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
            player.transform.position = Vector3.MoveTowards(player.transform.position, point, speed * Time.deltaTime);
            Debug.Log("point" + point);
         //   Debug.Log(player.transform.position);
            // targetPos = new Vector3(t.X, transform.position.y, t.Y);
            // player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed * Time.deltaTime);
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
                 
                ray = camera.ScreenPointToRay(new Vector2(t.X, t.Y));
                if (Physics.Raycast(ray, enter))
                {
                    point = ray.GetPoint(enter);
                  
                }
                point.y = transform.position.y;


              /**  t = FirstTouch(touches);
                Debug.Log("the update tap  = " + t.X + ", Y: " + t.Y);
                inWorldPosition = camera.ScreenToWorldPoint(new Vector3(t.X, t.Y, camera.nearClipPlane));
                inWorldPosition.y = 0;
                playerPos = player.transform.position;
                playerCameraPos = Camera.main.WorldToScreenPoint(playerPos);
                Vector2 direction = new Vector2(t.X, t.Y) - playerCameraPos;
                Vector2.Distance(playerCameraPos, new Vector2(t.X, t.Y));
              //  Debug.Log("playerPos" + playerPos);
                Debug.Log("direction = " + direction);
                Debug.Log("playerCamera = " + playerCameraPos);
             //   Debug.Log("Where he actually goes = " + inWorldPosition);**/
            }
         
        }        

      //  private void Awake()
        //{
           // joyStickScript.JoystickExecuted = joystickExecuted;
           // joyStickScript.MoveJoystickToGestureStartLocation = MoveJoysticktoGestureStartLocation;
      //  }

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