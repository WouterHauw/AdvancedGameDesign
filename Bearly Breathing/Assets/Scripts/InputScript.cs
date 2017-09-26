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
            Vector3 pos = player.transform.position;
            pos.x += (amount.x * speed * Time.deltaTime);
            pos.z += (amount.y * speed * Time.deltaTime);
            Vector3 faceDirection = pos - player.transform.position;
            var step = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(player.transform.forward, faceDirection, step, 0.0f);
            player.transform.position = pos;
            player.transform.rotation = Quaternion.LookRotation(newDirection);
            


        }
    }
}