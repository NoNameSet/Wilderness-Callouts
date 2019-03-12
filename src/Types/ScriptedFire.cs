﻿namespace WildernessCallouts.Types
{
    using Rage;
    using Rage.Native;

    internal class ScriptedFire
    {
        public int Handle { get; private set; }
        public Vector3 Position { get; private set; }
        public int Children { get; private set; }
        public bool IsGasFire { get; private set; }

        public ScriptedFire(Vector3 position, int children, bool isGasFire)
        {
            Position = position;
            Children = children;
            IsGasFire = isGasFire;
            Handle = NativeFunction.CallByName<int>("START_SCRIPT_FIRE", position.X, position.Y, position.Z, children, isGasFire);
        }

        public void Remove()
        {
            if (Handle == -1) return;

            NativeFunction.CallByName<uint>("REMOVE_SCRIPT_FIRE", Handle);
            Handle = -1;
        }
    }
}
