using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerSprintingState : PlayerMovingState {

        private PlayerSprintData sprintData;

        private bool keepSprinting;
        private float startTime;
        private bool shouldResetSprintState;

        public PlayerSprintingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine) {
            sprintData = movementData.SprintData;
        }

        #region IState Methods
        public override void Enter() {
            stateMachine.ReusableData.MovementSpeedModifier = movementData.SprintData.SpeedModifier;

            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.SprintParametrerHash);

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;

            shouldResetSprintState = true;

            if (!stateMachine.ReusableData.ShouldSprint)
                keepSprinting = false;

            startTime = Time.time;
        }
        public override void Update() {
            base.Update();

            if (keepSprinting)
                return;

            if (Time.time < startTime + sprintData.SprintToRunTime)
                return;

            StopSprinting();
        }
        public override void Exit() {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.SprintParametrerHash);

            if (shouldResetSprintState) { 
                keepSprinting = false;
                stateMachine.ReusableData.ShouldSprint = false;
            }


        }
        #endregion

        #region Main Methods
        private void StopSprinting() {
            if (stateMachine.ReusableData.MovementInput == Vector2.zero) {
                stateMachine.ChangeState(stateMachine.HardStoppingState); // ToDo: StoppingState
                return;
            }

            stateMachine.ChangeState(stateMachine.RunningState);
        }
        #endregion

        #region Reusable Methods
        protected override void AddInputActionsCallbacks() {
            base.AddInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Sprint.performed += OnSprintPerformed;
        }
        protected override void RemoveInputActionsCallbacks() {
            base.RemoveInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Sprint.performed -= OnSprintPerformed;
        }
        protected override void OnFall() {
            shouldResetSprintState = false;
            base.OnFall();
        }
        #endregion

        #region Input Methods
        protected override void OnMovementCanceled(InputAction.CallbackContext context) {
            stateMachine.ChangeState(stateMachine.HardStoppingState);

            base.OnMovementCanceled(context);
        }
        protected override void OnJumpStarted(InputAction.CallbackContext context) {
            shouldResetSprintState = false;
            base.OnJumpStarted(context);
        }
        private void OnSprintPerformed(InputAction.CallbackContext context) {
            keepSprinting = true;

            stateMachine.ReusableData.ShouldSprint = true;
        }
        #endregion
    }
}
