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
        //private static readonly List<BlockNameEntry<>> nameConvertList = new List<BlockNameEntry<IMyEntity>>()
        //{
        //    new BlockNameEntry<IMyAirVent>("Vent", true),
        //    new BlockNameEntry<IMyBatteryBlock>("Batt", true),
        //    new BlockNameEntry<IMySolarPanel>(string.Empty, true),
        //    new BlockNameEntry<IMyGyro>("Gyro", true),
        //};


        public static class BlockNamer
        {
            
            //new BlockNameEntry<IMyAirVent>("Vent", true);
            //new BlockNameEntry<IMyBatteryBlock>("Batt", true);
            //new BlockNameEntry<IMySolarPanel>(string.Empty, true);
            //new BlockNameEntry<IMyGyro>("Gyro", true);

            public static void RenameBlocks(Program p)
            {
                //foreach(var b in nameConvertList)
                //{
                    
                //    //BlockRetriever.GetBlocksOfType(b.BlockType)
                //}
            }


            private static void SetName<T>(Program p, string name) where T : class
            {
                //var blocks = BlockRetriever.GetBlocksOfType()
            }

        }

        private class BlockNameEntry<T> where T : class
        {
            public T BlockType;
            public List<T> listStub;
            
            public string ShortName;
            public bool HideInTerminal;
            
            
            public BlockNameEntry(string shortName, bool hideInTerminal = false)
            {
                this.ShortName = shortName;
                this.HideInTerminal = hideInTerminal;
                this.listStub = new List<T>();
            }
        }
    }
}
