﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    public class FingersOrbitScript : MonoBehaviour
    {
        [Tooltip("The transform to orbit around.")]
        public Transform OrbitTarget;

        [Tooltip("The object to orbit around OrbitTarget.")]
        public Transform Orbiter;

        [Tooltip("The minimium distance to zoom towards to the orbit target.")]
        [Range(0.1f, 100.0f)]
        public float MinZoomDistance = 5.0f;

        [Tooltip("The maximum distance to zoom away from the orbit target.")]
        [Range(0.1f, 1000.0f)]
        public float MaxZoomDistance = 1000.0f;

        [Tooltip("The zoom speed")]
        [Range(0.01f, 3.0f)]
        public float ZoomSpeed = 3.0f;

        [Tooltip("The speed (degrees per second) at which to orbit using x delta pan gesture values. Negative or positive values will cause orbit in the opposite direction.")]
        [Range(-100.0f, 100.0f)]
        public float OrbitXSpeed = -30.0f;

        [Tooltip("The maximum degrees to orbit on the x axis from the starting x rotation. 0 for no limit. Set OrbitXSpeed to 0 to disable x orbit.")]
        [Range(0.0f, 360.0f)]
        public float OrbitXMaxDegrees = 0.0f;

        [Tooltip("The speed (degrees per second) at which to orbit using y delta pan gesture values. Negative or positive values will cause orbit in the opposite direction.")]
        [Range(-100.0f, 100.0f)]
        public float OrbitYSpeed = -30.0f;

        [Tooltip("The maximum degrees to orbit on the y axis from the starting y rotation. 0 for no limit. Set OrbitYSpeed to 0 to disable y orbit.")]
        [Range(0.0f, 360.0f)]
        public float OrbitYMaxDegrees = 0.0f;

        [Tooltip("Whether to allow orbit while zooming.")]
        public bool AllowOrbitWhileZooming = true;
        private bool allowOrbitWhileZooming;

        private ScaleGestureRecognizer scaleGesture;
        private PanGestureRecognizer panGesture;
        private TapGestureRecognizer tapGesture;
        private float xDegrees;
        private float yDegrees;

        public event System.Action OrbitTargetTapped;

        private void Start()
        {
            // create a scale gesture to zoom orbiter in and out
            scaleGesture = new ScaleGestureRecognizer();
            scaleGesture.Updated += ScaleGesture_Updated;

            // pan gesture
            panGesture = new PanGestureRecognizer();
            panGesture.MaximumNumberOfTouchesToTrack = 2;
            panGesture.Updated += PanGesture_Updated;

            // create a tap gesture that only executes on the target, note that this requires a physics ray caster on the camera
            tapGesture = new TapGestureRecognizer();
            tapGesture.Updated += TapGesture_Updated;
            tapGesture.PlatformSpecificView = OrbitTarget;

            FingersScript.Instance.AddGesture(scaleGesture);
            FingersScript.Instance.AddGesture(panGesture);
            FingersScript.Instance.AddGesture(tapGesture);

            // point oribiter at target
            Orbiter.transform.LookAt(OrbitTarget.transform);
        }

        private void Update()
        {
            if (allowOrbitWhileZooming != AllowOrbitWhileZooming)
            {
                allowOrbitWhileZooming = AllowOrbitWhileZooming;
                if (allowOrbitWhileZooming)
                {
                    scaleGesture.AllowSimultaneousExecution(panGesture);
                }
                else
                {
                    scaleGesture.DisallowSimultaneousExecution(panGesture);
                }
            }
            scaleGesture.ZoomSpeed = ZoomSpeed;
        }

        private void TapGesture_Updated(GestureRecognizer gesture, ICollection<GestureTouch> touches)
        {
            if (gesture.State == GestureRecognizerState.Ended)
            {
                Debug.Log("Orbit target tapped!");
                if (OrbitTargetTapped != null)
                {
                    OrbitTargetTapped.Invoke();
                }
            }
        }

        private void PanGesture_Updated(GestureRecognizer gesture, ICollection<GestureTouch> touches)
        {
            // if gesture is not executing, exit function
            if (gesture.State != GestureRecognizerState.Executing)
            {
                return;
            }

            // orbit the target in either direction depending on pan gesture delta x and y
            if (OrbitXSpeed != 0.0f)
            {
                float addAngle = panGesture.DeltaY * OrbitXSpeed * Time.deltaTime;
                if (OrbitXMaxDegrees > 0.0f)
                {
                    float newDegrees = xDegrees + addAngle;
                    if (newDegrees > OrbitXMaxDegrees)
                    {
                        addAngle = OrbitXMaxDegrees - xDegrees;
                    }
                    else if (newDegrees < -OrbitXMaxDegrees)
                    {
                        addAngle = -OrbitXMaxDegrees - xDegrees;
                    }
                }
                xDegrees += addAngle;
                Orbiter.RotateAround(OrbitTarget.transform.position, Orbiter.transform.right, addAngle);
            }
            if (OrbitYSpeed != 0.0f)
            {
                float addAngle = panGesture.DeltaX * OrbitYSpeed * Time.deltaTime;
                if (OrbitYMaxDegrees > 0.0f)
                {
                    float newDegrees = yDegrees + addAngle;
                    if (newDegrees > OrbitYMaxDegrees)
                    {
                        addAngle = OrbitYMaxDegrees - yDegrees;
                    }
                    else if (newDegrees < -OrbitYMaxDegrees)
                    {
                        addAngle = -OrbitYMaxDegrees - yDegrees;
                    }
                }
                yDegrees += addAngle;
                Orbiter.RotateAround(OrbitTarget.transform.position, Vector3.up, addAngle);
            }
        }

        private void ScaleGesture_Updated(GestureRecognizer gesture, ICollection<GestureTouch> touches)
        {
            // if gesture is not executing, exit function
            if (gesture.State != GestureRecognizerState.Executing)
            {
                return;
            }

            // get the current distance from the target
            float currentDistanceFromTarget = Vector3.Distance(Orbiter.transform.position, OrbitTarget.transform.position);

            // invert the scale so that smaller scales actually zoom out and larger scales zoom in
            float scale = 1.0f + (1.0f - scaleGesture.ScaleMultiplier);

            // multiply by scale, clamping to min and max
            currentDistanceFromTarget = Mathf.Clamp(currentDistanceFromTarget * scale, MinZoomDistance, MaxZoomDistance);

            // position orbiter away from the target at the new distance
            Orbiter.transform.position = Orbiter.transform.forward * (-currentDistanceFromTarget);
        }
    }
}
