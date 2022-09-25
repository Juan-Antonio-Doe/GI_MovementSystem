using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerRollingState : PlayerLandingState {

        private PlayerRollData rollData;

        public PlayerRollingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine) {
            rollData = movementData.RollData;
        }

        #region IState Methods
        public override void Enter() {
            stateMachine.ReusableData.MovementSpeedModifier = movementData.RollData.SpeedModifier;

            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.RollParametrerHash);

            stateMachine.ReusableData.ShouldSprint = false;
        }
        public override void PhysicsUpdate() {
            base.PhysicsUpdate();

            if (stateMachine.ReusableData.MovementInput != Vector2.zero)
                return;

            RotateTowardsTargetRotation();
        }
        public override void Exit() {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.RollParametrerHash);
        }
        public override void OnAnimationTransitionEvent() {
            if (stateMachine.ReusableData.MovementInput == Vector2.zero) {
                stateMachine.ChangeState(stateMachine.MediumStoppingState);
                return;
            }

            OnMove();
        }
        #endregion

        #region Main Methods

        #endregion

        #region Reusable Methods

        #endregion

        #region Input Methods
        protected override void OnJumpStarted(InputAction.CallbackContext context) {
        }
        #endregion
    }
}
