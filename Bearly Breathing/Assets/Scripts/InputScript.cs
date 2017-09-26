using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    public class InputScript : MonoBehaviour {



        public FingersJoystickScript joyStickScript;
        // Update is called once per frame
        public GameObject player;

        public float speed = 10.0f;

        public bool MoveJoysticktoGestureStartLocation;

        private void Awake()
        {
            joyStickScript.JoystickExecuted = joystickExecuted;
            joyStickScript.MoveJoystickToGestureStartLocation = MoveJoysticktoGestureStartLocation;
        }

        private void joystickExecuted(FingersJoystickScript script, Vector2 amount)
        {
            Debug.Log("kek");
            Vector3 pos = player.transform.position;
            pos.x += (amount.x * speed * Time.deltaTime);
            pos.z += (amount.y * speed * Time.deltaTime);
            Vector3 faceDirection = pos - player.transform.position;
  
            player.transform.position = pos;
            
            Debug.Log("playerPos"+ player.GetComponent<Rigidbody>().position);
            


        }
    }
}