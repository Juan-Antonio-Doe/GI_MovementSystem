using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour {

        [field: Header("References")]
        [field: SerializeField] public PlayerSO Data { get; private set; }

        [field: Header("Collisions")]
        [field: SerializeField] public PlayerCapsuleColliderUtility ColliderUtility { get; private set; }
        [field: SerializeField] public PlayerLayerData LayerData { get; private set; }

        [field: Header("Camera")]
        [field: SerializeField] public PlayerCameraUtility CameraUtility { get; private set; }

        [field: Header("Animations")]
        [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

        private PlayerMovementStateMachine movementStateMachine;
        public PlayerInput Input { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public Animator Animator { get; private set; }
        public Transform mainCameraTransform { get; private set; }


        private void Awake() {
            Input = GetComponent<PlayerInput>();
            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponentInChildren<Animator>();

            ColliderUtility.Initializate(gameObject);
            ColliderUtility.CalculateCapsuleColliderDimensions();

            CameraUtility.Initialize();

            AnimationData.Initialize();

            mainCameraTransform = Camera.main.transform;
            movementStateMachine = new PlayerMovementStateMachine(this);
        }

        private void Start() {
            movementStateMachine.ChangeState(movementStateMachine.IdlingState);
        }

        private void OnTriggerEnter(Collider collider) {
            movementStateMachine.OnTriggerEnter(collider);
        }
        private void OnTriggerExit(Collider collider) {
            movementStateMachine.OnTriggerExit(collider);
        }

        private void OnValidate() {
            ColliderUtility.Initializate(gameObject);
            ColliderUtility.CalculateCapsuleColliderDimensions();
        }

        private void Update() {
            movementStateMachine.HandleInput();
            movementStateMachine.Update();
        }

        private void FixedUpdate() {
            movementStateMachine.PhysicsUpdate();
        }

        #region Animation Methods
        public void OnMovementStateAnimationEnterEvent() {
            movementStateMachine.OnAnimationEnterEvent();
        }
        public void OnMovementStateAnimationExitEvent() {
            movementStateMachine.OnAnimationExitEvent();
        }
        public void OnMovementStateAnimationTransitionEvent() {
            movementStateMachine.OnAnimationTransitionEvent();
        }
        #endregion
    }
}
