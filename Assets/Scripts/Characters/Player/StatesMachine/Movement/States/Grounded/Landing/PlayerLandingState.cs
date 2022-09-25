using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerLandingState : PlayerGroundedState {
        public PlayerLandingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine) {

        }

        #region IState Methods
        public override void Enter() {
            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.LandingParametrerHash);

            DisableCameraRecentering();
        }
        public override void Exit() {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.LandingParametrerHash);
        }
        #endregion

        #region Main Methods

        #endregion

        #region Reusable Methods

        #endregion

        #region Input Methods
        /*// Removed for keep horizontal rotation on Camera.
        protected virtual void OnMovementCanceled(InputAction.CallbackContext context) {

        }*/
        #endregion
    }
}
