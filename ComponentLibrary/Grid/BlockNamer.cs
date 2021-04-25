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
                new BlockNameEntry<IMyAirVent>(p, "Vent", true);
                new BlockNameEntry<IMyBatteryBlock>(p, "Batt", true);
                new BlockNameEntry<IMySolarPanel>(p, string.Empty, true);
                new BlockNameEntry<IMyGyro>(p, "Gyro", true);

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

        private class BlockNameEntry<T> where T : class, IMyTerminalBlock
        {
            private Program p;
            public T BlockType;
            public List<T> listStub;
            
            public string ShortName;
            public bool HideInTerminal;
            
            
            public BlockNameEntry(Program p, string shortName, bool hideInTerminal = false)
            {
                this.p = p;
                this.ShortName = shortName;
                this.HideInTerminal = hideInTerminal;
                this.listStub = new List<T>();
            }

            public void ConvertEntry()
            {
                BlockRetriever.GetBlocksOfType(p, out this.listStub);
                string oldNamme;
                foreach(var entry in listStub)
                {
                    oldNamme = entry.DefinitionDisplayNameText;
                    entry.CustomName = RemoveSubstring(entry.CustomName, oldNamme);
                    
                }
            }

            private string RemoveSubstring(string source, string substring)
            {
                int index = source.IndexOf(substring);
                return (index < 0)
                    ? source
                    : source.Remove(index, substring.Length);
            }
        }
    }
}
