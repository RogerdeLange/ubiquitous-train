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
        // Name structure: [prefix] Blockname index Other
        public class BlockNameFormatter
        {
            private Program p;
            private IMyTerminalBlock Block;
            public string Prefix { get; set; }
            public string Name { get; set; }
            public int Index { get; set; }

            public string Other { get; set; }

            public BlockNameFormatter(Program p, IMyTerminalBlock block)
            {
                this.p = p;
                GetNameComponents();
            }

            private void GetNameComponents()
            {
                
            }
        }
    }
}
