using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerLightLandingState : PlayerLandingState {
        public PlayerLightLandingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine) {

        }

        #region IState Methods
        public override void Enter() {
            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            base.Enter();

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StationaryForce;

            ResetVelocity();
        }
        public override void Update() {
            base.Update();

            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
                return;

            OnMove();
        }
        public override void PhysicsUpdate() {
            base.PhysicsUpdate();

            if (!IsMovingHorizontally())
                return;

            ResetVelocity();
        }
        public override void OnAnimationTransitionEvent() {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }
        #endregion

        #region Main Methods

        #endregion

        #region Reusable Methods

        #endregion

        #region Input Methods

        #endregion
    }
}
