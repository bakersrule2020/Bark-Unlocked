﻿using Bark.Extensions;
using Bark.Gestures;
using Bark.GUI;
using Bark.Tools;
using System;
using UnityEngine;

namespace Bark.Modules.Misc
{
    public class RatSword : BarkModule
    {
        private GameObject sword;
        protected override void OnEnable()
        {
            if (!MenuController.Instance.Built) return;
            base.OnEnable();

            try
            {
                sword = Instantiate(Plugin.assetBundle.LoadAsset<GameObject>("Rat Sword"));
                sword.transform.SetParent(GestureTracker.Instance.rightHand.transform, true);
                sword.transform.localPosition = new Vector3(-0.4782f, 0.1f, 0.4f);
                sword.transform.localRotation = Quaternion.Euler(9, 0, 0);
                sword.transform.localScale /= 2;
                sword.SetActive(false);
                GestureTracker.Instance.OnRightGripPressed += () => { sword.SetActive(true); };
                GestureTracker.Instance.OnRightGripReleased += () => { sword.SetActive(false); };
            }
            catch (Exception e) { Logging.LogException(e); }
        }

        protected override void Cleanup()
        {
            sword?.Obliterate();
        }

        public override string DisplayName()
        {
            return "Rat Sword";
        }

        public override string Tutorial()
        {
            return "I met a lil' kid in canyons who wanted me to make him a sword.\n" +
                "[Grip] to wield your weapon, rat kid.";
        }
    }
}
