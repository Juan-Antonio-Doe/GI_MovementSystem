using System;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerFallingState : PlayerAirborneState {

        private PlayerFallData fallData;

        private Vector3 playerPositionOnEnter;

        public PlayerFallingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine) {
            fallData = airborneData.FallData;
        }

        #region IState Methods
        public override void Enter() {
            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.FallParametrerHash);

            playerPositionOnEnter = stateMachine.Player.transform.position;

            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            ResetVerticalVelocity();
        }
        public override void PhysicsUpdate() {
            base.PhysicsUpdate();

            LimitVerticalVelocity();
        }
        public override void Exit() {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.FallParametrerHash);
        }
        #endregion

        #region Main Methods
        private void LimitVerticalVelocity() {
            Vector3 playerVerticalVelocity = GetPlayerVerticalVelocity();

            if (playerVerticalVelocity.y >= -fallData.FallSpeedLimit)
                return;

            Vector3 limitedVelocity = new Vector3(0f, -fallData.FallSpeedLimit - playerVerticalVelocity.y, 0f);

            stateMachine.Player.Rigidbody.AddForce(limitedVelocity, ForceMode.VelocityChange);
        }
        #endregion

        #region Reusable Methods
        protected override void ResetSprintState() {

        }
        protected override void OnContactWithGround(Collider collider) {
            float fallDistance = playerPositionOnEnter.y - stateMachine.Player.transform.position.y;

            if (fallDistance < fallData.MinimumDistanceToBeConsideredHardFall) {
                stateMachine.ChangeState(stateMachine.LightLandingState);
                return;
            }

            if (stateMachine.ReusableData.ShouldWalk && !stateMachine.ReusableData.ShouldSprint || stateMachine.ReusableData.MovementInput == Vector2.zero) {
                stateMachine.ChangeState(stateMachine.HardLandingState);
                return;
            }

            stateMachine.ChangeState(stateMachine.RollingState);

            //Aqu� se a�adir�a el da�o de caida al jugador.
        }
        #endregion

        #region Input Methods

        #endregion
    }
}
