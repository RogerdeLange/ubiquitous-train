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
        public static class BlockRetriever
        {
            private static List<IMyTerminalBlock> blocks;

            public static void GetBlocksOfType<T>(Program p, out List<T> list, Func<T, bool> where = null, bool mainBlocksOnly = true) where T : class, IMyTerminalBlock
            {
                list = new List<T>();
                if (blocks == null)
                    PopulateInternalList(p);

                p.Echo("Retrieving blocks of type " + typeof(T).Name);
                if(where == null)
                {
                    p.GridTerminalSystem.GetBlocksOfType(list);
                }
                else
                {
                    p.GridTerminalSystem.GetBlocksOfType(list, where);
                }
                
                if (mainBlocksOnly)
                    list = RemoveSupergridBlocks(p, list);
            }

            private static void PopulateInternalList(Program p)
            {
                blocks = new List<IMyTerminalBlock>();
                p.GridTerminalSystem.GetBlocks(blocks);
                p.Echo("Setting up cache with block count " + blocks.Count);
            }

            private static List<T> RemoveSupergridBlocks<T>(Program p, List<T> blocks) where T : class, IMyTerminalBlock
            {
                List<T> newList = new List<T>();
                foreach (T cur in blocks)
                {
                    if (cur.CubeGrid == p.Me.CubeGrid)
                    {
                        newList.Add(cur);
                    }
                }

                return newList;
            }
        }
    }
}
