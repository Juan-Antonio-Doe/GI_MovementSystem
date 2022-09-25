using System;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    [Serializable]
    public class PlayerAnimationData {
        [Header("State Group Parametrer Names")]
        [SerializeField] private string groundedParametrerName = "Grounded";
        [SerializeField] private string movingParametrerName = "Moving";
        [SerializeField] private string stoppingParametrerName = "Stopping";
        [SerializeField] private string landingParametrerName = "Landing";
        [SerializeField] private string airborneParametrerName = "Airborne";
        
        [Header("Grounded Parametrer Names")]
        [SerializeField] private string idleParametrerName = "isIdling";
        [SerializeField] private string dashParametrerName = "isDashing";
        [SerializeField] private string walkParametrerName = "isWalking";
        [SerializeField] private string runParametrerName = "isRunning";
        [SerializeField] private string sprintParametrerName = "isSprinting";
        [SerializeField] private string mediumStopParametrerName = "isMediumStopping";
        [SerializeField] private string hardStoppingParametrerName = "isHardStopping";
        [SerializeField] private string rollParametrerName = "isRolling";
        [SerializeField] private string hardLandParametrerName = "isHardLanding";

        [Header("Airborne Parametrer Names")]
        [SerializeField] private string fallParametrerName = "isFalling";

        public int GroundedParametrerHash { get; private set; }
        public int MovingParametrerHash { get; private set; }
        public int StoppingParametrerHash { get; private set; }
        public int LandingParametrerHash { get; private set; }
        public int AirborneParametrerHash { get; private set; }

        public int IdleParametrerHash { get; private set; }
        public int DashParametrerHash { get; private set; }
        public int WalkParametrerHash { get; private set; }
        public int RunParametrerHash { get; private set; }
        public int SprintParametrerHash { get; private set; }
        public int MediumStopParametrerHash { get; private set; }
        public int HardStopParametrerHash { get; private set; }
        public int RollParametrerHash { get; private set; }
        public int HardLandParametrerHash { get; private set; }

        public int FallParametrerHash { get; private set; }

        public void Initialize() {
            GroundedParametrerHash = Animator.StringToHash(groundedParametrerName);
            MovingParametrerHash = Animator.StringToHash(movingParametrerName);
            StoppingParametrerHash = Animator.StringToHash(stoppingParametrerName);
            LandingParametrerHash = Animator.StringToHash(landingParametrerName);
            AirborneParametrerHash = Animator.StringToHash(airborneParametrerName);

            IdleParametrerHash = Animator.StringToHash(idleParametrerName);
            DashParametrerHash = Animator.StringToHash(dashParametrerName);
            WalkParametrerHash = Animator.StringToHash(walkParametrerName);
            RunParametrerHash = Animator.StringToHash(runParametrerName);
            SprintParametrerHash = Animator.StringToHash(sprintParametrerName);
            MediumStopParametrerHash = Animator.StringToHash(mediumStopParametrerName);
            HardStopParametrerHash = Animator.StringToHash(hardStoppingParametrerName);
            RollParametrerHash = Animator.StringToHash(rollParametrerName);
            HardLandParametrerHash = Animator.StringToHash(hardLandParametrerName);

            FallParametrerHash = Animator.StringToHash(fallParametrerName);
        }
    }
}
