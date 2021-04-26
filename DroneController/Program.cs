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
        NavLightController navLightController;
        List<IMyRemoteControl> controlBlocks = new List<IMyRemoteControl>();
        AutoPilotController AutoPilot;
        bool setup;

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
            Run(argument, updateSource);
        }


        private void Setup()
        {
            this.navLightController = new NavLightController(this);
            BlockRetriever.GetBlocksOfType(this, out controlBlocks);
            AutoPilot = new AutoPilotController(this, controlBlocks.First());
        }


        private void Run(string argument, UpdateType updateSource)
        {
            Echo(TickIndicator.Get());
            if (AutoPilot.IsActive)
                Runtime.UpdateFrequency = UpdateFrequency.Update1;
            else
                Runtime.UpdateFrequency = UpdateFrequency.Update100;

            navLightController.Tick();
            AutoPilot.Tick();
            if (!string.IsNullOrEmpty(argument))
            {
                int distance = int.Parse(argument);
                AutoPilot.CommandMoveDirection(new Vector3D(distance, 0, 0));
            }
        }
    }
}
