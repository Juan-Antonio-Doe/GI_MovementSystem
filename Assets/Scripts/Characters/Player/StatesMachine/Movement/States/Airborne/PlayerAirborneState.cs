using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerAirborneState : PlayerMovementState {
        public PlayerAirborneState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine) {

        }

        #region IState Methods
        public override void Enter() {
            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.AirborneParametrerHash);

            ResetSprintState();
        }
        public override void Exit() {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.AirborneParametrerHash);
        }
        #endregion

        #region Main Methods

        #endregion

        #region Reusable Methods
        protected override void OnContactWithGround(Collider collider) {
            stateMachine.ChangeState(stateMachine.LightLandingState);
        }
        protected virtual void ResetSprintState() {
            stateMachine.ReusableData.ShouldSprint = false;
        }
        #endregion

        #region Input Methods

        #endregion
    }
}
