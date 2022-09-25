using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerHardStoppingState : PlayerStoppingState {
        public PlayerHardStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine) {

        }

        #region IState Methods
        public override void Enter() {
            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.HardStopParametrerHash);

            stateMachine.ReusableData.MovementDecelerationForce = movementData.StopData.HardDecelerationForce;
            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;
        }
        public override void Exit() {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.HardStopParametrerHash);
        }
        #endregion

        #region Main Methods

        #endregion

        #region Reusable Methods
        protected override void OnMove() {
            if (stateMachine.ReusableData.ShouldWalk)
                return;

            stateMachine.ChangeState(stateMachine.RunningState);
        }
        #endregion

        #region Input Methods

        #endregion
    }
}
