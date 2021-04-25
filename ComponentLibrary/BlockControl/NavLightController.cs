using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        public class NavLightController
        {
            private const string NAVL = "navl";
            private const string NAVR = "navr";
            private Program p;
            List<IMyInteriorLight> lightBlocks = new List<IMyInteriorLight>();
            List<IMyRemoteControl> controlBlocks = new List<IMyRemoteControl>();
            bool lightsOn = false;

            public NavLightController(Program p)
            {
                this.p = p;
                BlockRetriever.GetBlocksOfType(p, out lightBlocks, r => r.CustomName.ToLower().Contains(NAVL) || r.CustomName.ToLower().Contains(NAVR));
                BlockRetriever.GetBlocksOfType(p, out controlBlocks);

                foreach (var light in lightBlocks.Where(r => r.CustomName.ToLower().Contains(NAVL)))
                {
                    light.Color = Color.Red;
                }
                foreach (var light in lightBlocks.Where(r => r.CustomName.ToLower().Contains(NAVR)))
                {
                    light.Color = Color.Green;
                }
            }

            public void Tick()
            {
                lightsOn = controlBlocks.Where(r => r.IsUnderControl || r.IsAutoPilotEnabled).Any();
                if (lightsOn)
                    TurnOn();
                if (!lightsOn)
                    TurnOff();
            }

            private void TurnOn()
            {
                foreach(var light in lightBlocks)
                {
                    light.BlinkIntervalSeconds = 1f;
                    light.BlinkLength = 80f;
                    light.Enabled = true;
                }
            }

            private void TurnOff()
            {
                foreach (var light in lightBlocks)
                {
                    light.BlinkIntervalSeconds = 0;
                    light.BlinkLength = 0;
                    light.Enabled = false;
                }
            }
        }
    }
}
