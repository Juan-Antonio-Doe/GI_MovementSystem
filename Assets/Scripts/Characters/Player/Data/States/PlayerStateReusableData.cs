using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerStateReusableData {

        public PlayerRotationData RotationData { get; set; }

        public Vector2 MovementInput { get; set; }
        public float MovementSpeedModifier { get; set; } = 1f;
        public float MovementOnSlopesSpeedModifier { get; set; } = 1f;
        public float MovementDecelerationForce { get; set; } = 1f;
        public bool ShouldWalk { get; set; }
        public bool ShouldSprint { get; set; }

        public List<PlayerCameraRecenteringData> SidewaysCameraRecenteringData { get; set; }
        public List<PlayerCameraRecenteringData> BackwardsCameraRecenteringData { get; set; }


        /*
         * Vector properties for rotation.
         */
        private Vector3 currentTargetRotation;
        private Vector3 timeToReachTargetRotation;
        private Vector3 dampedTargetRotationCurrentVelocity;
        private Vector3 dampedTargetRotationPassedTime;
        public ref Vector3 CurrentTargetRotation {
            get {
                return ref currentTargetRotation;
            }
        }
        public ref Vector3 TimeToReachTargetRotation {
            get {
                return ref timeToReachTargetRotation;
            }
        }
        public ref Vector3 DampedTargetRotationCurrentVelocity {
            get {
                return ref dampedTargetRotationCurrentVelocity;
            }
        }
        public ref Vector3 DampedTargetRotationPassedTime {
            get {
                return ref dampedTargetRotationPassedTime;
            }
        }

        /*
         * Vector properties for jump.
         */
        public Vector3 CurrentJumpForce { get; set; }

    }
}
