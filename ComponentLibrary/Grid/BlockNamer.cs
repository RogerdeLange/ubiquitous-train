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
        private static readonly List<BlockNameEntry> nameConvertList = new List<BlockNameEntry>()
        {
            new BlockNameEntry(typeof(IMyAirVent), "Vent", true),
            new BlockNameEntry(typeof(IMyBatteryBlock), "Batt", true),
            new BlockNameEntry(typeof(IMySolarPanel), string.Empty, true),
            new BlockNameEntry(typeof(IMyGyro), "Gyro", true),
        };


        public static class BlockNamer
        {
            public static void RenameBlocks(Program p)
            {
                foreach(var b in nameConvertList)
                {
                    
                    //BlockRetriever.GetBlocksOfType(b.BlockType)
                }
            }
        }

        private class BlockNameEntry 
        {
            public readonly Type BlockType;
            
            public readonly string ShortName;
            public readonly bool HideInTerminal;

            public BlockNameEntry(Type blockType, string shortName, bool hideInTerminal = false){
                this.BlockType = blockType;
                this.ShortName = shortName;
                this.HideInTerminal = hideInTerminal;
            }
        }
    }
}
