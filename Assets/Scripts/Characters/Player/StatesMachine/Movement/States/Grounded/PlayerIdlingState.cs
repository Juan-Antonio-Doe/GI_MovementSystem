using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerIdlingState : PlayerGroundedState {

        private PlayerIdleData idleData;

        public PlayerIdlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine) {
            idleData = movementData.IdleData;
        }

        #region IState Methods
        public override void Enter() {
            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            stateMachine.ReusableData.BackwardsCameraRecenteringData = idleData.BackwardsCameraRecenteringData;

            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.IdleParametrerHash);

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StationaryForce;

            ResetVelocity();
        }
        public override void Exit() {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.IdleParametrerHash);
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
        #endregion
    }
}
