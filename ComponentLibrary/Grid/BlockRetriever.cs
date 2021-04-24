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
            private static List<IMyEntity> blocks;

            public static IEnumerable<T> GetBlocksOfType<T>(Program p, bool mainBlocksOnly = true) where T : IMyEntity
            {
                if (blocks == null)
                    PopulateInternalList(p);
                return (IEnumerable<T>)blocks.Where(r => r.GetType() == typeof(T));
            }

            private static void PopulateInternalList(Program p)
            {
                blocks = new List<IMyEntity>();
                p.GridTerminalSystem.GetBlocksOfType(blocks);
            }
        }
    }
}
