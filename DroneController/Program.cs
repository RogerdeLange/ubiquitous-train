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
    partial class Program : MyGridProgram
    {
        List<IMyRemoteControl> controlBlocks = new List<IMyRemoteControl>();
        List<IMyInteriorLight> lightBlocks = new List<IMyInteriorLight>();
        bool shipActive;
        bool setup;
        bool alternateLightState;

        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
        }

        public void Save()
        {

        }

        public void Main(string argument, UpdateType updateSource)
        {
            Echo("Script running...");

            if (!setup)
            {
                Setup();
                setup = true;
                return;
            }

            Run();
        }


        private void Setup()
        {
            BlockRetriever.GetBlocksOfType(this, out controlBlocks);
            BlockRetriever.GetBlocksOfType(this, out lightBlocks);

            for (int i = 0; i < lightBlocks.Count; i++)
            {
                lightBlocks[i].BlinkIntervalSeconds = 1f;
                lightBlocks[i].BlinkLength = 80f;
                if (lightBlocks[i].CustomName.ToLower().Contains("navl"))
                    lightBlocks[i].Color = Color.Red;

                if (lightBlocks[i].CustomName.ToLower().Contains("navr"))
                    lightBlocks[i].Color = Color.Green;
            }
        }


        private void Run()
        {
            Echo("Lights under control: " + lightBlocks.Count);
            if (lightBlocks == null || lightBlocks.Count == 0)
            {
                Echo("No light blocks controlled named 'nav'");
                return;
            }

            
            shipActive = this.GetShipIsActive(ref controlBlocks);
            this.ControlWarningLights(shipActive, ref lightBlocks);
            alternateLightState = !alternateLightState;
        }



        private bool GetShipIsActive(ref List<IMyRemoteControl> controls)
        {
            if (controls != null)
            {
                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i].IsUnderControl || controls[i].IsAutoPilotEnabled)
                        return true;
                }
            }
            return false;
        }

        private void ControlWarningLights(bool enabled, ref List<IMyInteriorLight> lights)
        {
            if (lights != null)
            {
                for (int i = 0; i < lights.Count; i++)
                {
                    lights[i].Enabled = enabled;
                }
            }
        }
    }
}
