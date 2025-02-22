﻿using Bark.GUI;
using GorillaLocomotion;
using UnityEngine;

namespace Bark.Modules.Physics
{
    public class Freeze : BarkModule
    {
        public static Freeze Instance;

        void Awake() { Instance = this; }

        protected override void OnEnable()
        {
            if (!MenuController.Instance.Built) return;
            base.OnEnable();
            Player.Instance.bodyCollider.attachedRigidbody.isKinematic = true;
        }

        protected override void Cleanup()
        {
            Player.Instance.bodyCollider.attachedRigidbody.isKinematic = false;
        }

        public override string DisplayName()
        {
            return "Freeze";
        }

        public override string Tutorial()
        {
            return "Effect: Freezes you in place.";
        }

    }
}
