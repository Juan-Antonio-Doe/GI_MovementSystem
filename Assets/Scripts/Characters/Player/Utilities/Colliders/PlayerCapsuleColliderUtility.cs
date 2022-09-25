using System;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    [Serializable]
    public class PlayerCapsuleColliderUtility : CapsuleColliderUtility {
        [field: SerializeField] public PlayerTriggerColliderData TriggerColliderData { get; private set; }

        protected override void OnIntialize() {
            base.OnIntialize();

            TriggerColliderData.Initialize();
        }
    }
}
