using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Strategy
{
	public class Ability1 : UseAbility
	{
		public override string Perform()
		{
			return "AbilityOneUsed";
		}
	}
}
