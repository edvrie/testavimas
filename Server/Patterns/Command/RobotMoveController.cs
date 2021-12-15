using ObjektinisProgramuProjektavimas.Patterns.Proxy;
using ObjektinisProgramuProjektavimas.Patterns.Strategy;
using SignalRChat.Hubs;
using System.Collections.Generic;
using System.Linq;

namespace ObjektinisProgramuProjektavimas.Patterns.Command
{
	public class RobotMoveController : IProxy
	{
		private static List<Move> list = new List<Move>();
		private Robot robot;

		public RobotMoveController(Robot commRobot)
        {
			robot = commRobot;
        }

		public void Run(gameHub hub, Move move)
		{
			list.Add(move);
			robot.Move(move, hub);
		}

		public async void Undo(gameHub hub)
		{
			if (list.Count() > 0)
			{
				Move moveOld = list[list.Count() - 1];
				list.RemoveAt(list.Count() - 1);
				robot.Move(moveOld.Undo(), hub);
			}
		}

		public int GetListCount()
        {
			return list.Count();
		}
	}
}
