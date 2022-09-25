using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerMediumStoppingState : PlayerStoppingState {
        public PlayerMediumStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine) {

        }

        #region IState Methods
        public override void Enter() {
            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.MediumStopParametrerHash);

            stateMachine.ReusableData.MovementDecelerationForce = movementData.StopData.MediumDecelerationForce;
            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.MediumForce;
        }
        public override void Exit() {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.MediumStopParametrerHash);
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
