using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Strategy
{
	public abstract class Move
    {
        public string state { get; set; }
        public abstract string Perform();

        public abstract Move Undo();
    }
}
