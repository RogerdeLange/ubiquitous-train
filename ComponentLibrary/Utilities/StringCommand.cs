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
        /// <summary>
        /// Command string format: COMMAND1 #Argument1 #argument2; COMMAND2 #Argument1 #argument2;
        /// </summary>
        public class StringCommand
        {
            const string COMMANDDIVIDER = ";";
            

            List<KeyValuePair<string, StringCommandArg[]>> Commands = new List<KeyValuePair<string, StringCommandArg[]>>();

            public StringCommand()
            {

            }
            public StringCommand(string stringCommand)
            {

            }
        }

        public class StringCommandArg
        {
            const string ARGUMENTStart = "#";
            const string ARGUMENTDivider = ">";

            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
