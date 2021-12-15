using ObjektinisProgramuProjektavimas.Patterns.Bridge;
using ObjektinisProgramuProjektavimas.Patterns.Command;
using ObjektinisProgramuProjektavimas.Patterns.Singleton;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Proxy
{
    public class MoveProxy : IProxy
    {
        private Robot _robot;
        private Singleton.Singleton Map = Singleton.Singleton.GetInstance();
        private int[] NotAllowed = { 1, 2, 3 };
        RobotMoveController robCont;
        public MoveProxy(Robot robot)
        {
            _robot = robot;
            robCont = new RobotMoveController(robot);
        }

        public void Run(gameHub hub, Move move)
        {
            if (move is MoveLeft)
            {
                if (_robot.X - 1 < 0 || NotAllowed.Contains(Map.GetMap().objects[_robot.Y, _robot.X - 1]))
                {
                    return;
                }
            }
            if (move is MoveUp)
            {
                if (_robot.Y - 1 < 0 || NotAllowed.Contains(Map.GetMap().objects[_robot.Y - 1, _robot.X]))
                {
                    return;
                }
            }
            if (move is MoveRight)
            {
                if (_robot.X + 1 > Map.GetMap().size || NotAllowed.Contains(Map.GetMap().objects[_robot.Y, _robot.X + 1]))
                {
                    return;                
                }
            }
            if (move is MoveDown)
            {
                if (_robot.Y + 1 > Map.GetMap().size || NotAllowed.Contains(Map.GetMap().objects[_robot.Y + 1, _robot.X]))
                {
                    return;
                }
            }
            robCont.Run(hub, move);
        }

        public void Undo(gameHub hub)
        {
            robCont.Undo(hub);
        }
    }
}
