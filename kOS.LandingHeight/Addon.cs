using System;
using kOS.Safe.Encapsulation;
using kOS.Safe.Encapsulation.Suffixes;
using UnityEngine;

namespace kOS.AddOns.LandingHeight
{
    [kOSAddon("LH")]
    [Safe.Utilities.KOSNomenclature("LHAddon")]
    public class Addon : Suffixed.Addon
    {
        public Addon(SharedObjects shared) : base (shared)
        {
            InitializeSuffixes();
        }

        private void InitializeSuffixes()
        {
            AddSuffix("HEIGHT", new Suffix<ScalarValue>(GetHeight));
        }

        public ScalarValue GetHeight()
        {
            if (Available())
            {
                return LHWrapper.LandingHeight();
            }
            throw new Exception("Langing Height not found");
        }

        public override BooleanValue Available()
        {
            return LHWrapper.Wrapped();
        }
    }
}
