using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Strategy
{
	public class MoveDown : Move
	{
		public override string Perform()
		{
			state = "MoveDown";
			return "MoveDown";
		}

		public override Move Undo()
		{
			return new MoveUp();
		}
	}
}
