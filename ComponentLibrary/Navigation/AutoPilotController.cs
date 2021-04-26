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
        public class AutoPilotController
        {
            Program p;
            IMyRemoteControl Controller;
            List<MyWaypointInfo> Waypoints = new List<MyWaypointInfo>();

            public bool IsActive => Controller.IsAutoPilotEnabled || Controller.IsUnderControl;

            public AutoPilotController(Program p, IMyRemoteControl controller)
            {
                this.Controller = controller;
                
                this.p = p;
            }


            public void CommandMoveDirection(Vector3D direction)
            {
                Vector3D target = Vector3D.Transform(direction, Controller.WorldMatrix);
                Controller.AddWaypoint(target, "test target " + direction + " " + direction.ToString());
            }

            public void Tick()
            {
                p.Echo(new Vector3D(0,0,0).ToString());
                Controller.GetWaypointInfo(Waypoints);
                var pos = Controller.GetPosition();
                //var target = Vector3D.TransformNormal(new Vector3D(10, 0, 0), MatrixD.Transpose(Controller.WorldMatrix));
                p.Echo("Pos: " + pos.ToString());
                if (Waypoints.Any())
                {
                    var point = Waypoints.First();

                    p.Echo("Distance to waypoint: " + Vector3D.Distance(pos, point.Coords).ToString());
                }
                
                //p.Echo("test: " + Vector3D.Add(pos, target));
            }
        }
    }
}
