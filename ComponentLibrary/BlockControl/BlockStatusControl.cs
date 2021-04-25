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
        public class BlockStatusControl
        {
            private Program p;
            private const string Marker = "Status:";
            private List<IMyBatteryBlock> Batteries = new List<IMyBatteryBlock>();
            private List<IMyOxygenTank> OxygenTanks = new List<IMyOxygenTank>();
            private List<IMyGasTank> HydrogenTanks = new List<IMyGasTank>();
            private List<IMyAirVent> AirVents = new List<IMyAirVent>();
            int index;

            public BlockStatusControl(Program p)
            {
                this.p = p;
                BlockRetriever.GetBlocksOfType(p, out Batteries);
                BlockRetriever.GetBlocksOfType(p, out OxygenTanks);
                BlockRetriever.GetBlocksOfType(p, out HydrogenTanks);
                BlockRetriever.GetBlocksOfType(p, out AirVents);
            }

            public void Tick()
            {
                switch (index)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                index++;
            }
        }
    }
}
