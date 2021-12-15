using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Strategy
{
    public class MoveUp : Move
    {
        public override string Perform()
        {
            state = "MoveUp";
            return "MoveUp";
        }

        public override Move Undo()
        {
            return new MoveDown();
        }
    }
}
